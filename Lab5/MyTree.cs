namespace Lab5
{
	public class MyNode<T> : IRoot<T>
	{
		private int _key;
		private MyNode<T>? _left;
		private MyNode<T>? _right;
		private T? _value;
		private IRoot<T> _top;

		private MyNode() { }

		public MyNode(IRoot<T> top, int key, T value)
		{
			_top = top;
			_key = key;
			_value = value;
		}

		public T Search(int key)
		{
			if (key == _key)
			{
				return _value;
			}
			else
			{
				ref MyNode<T> child = ref GetChild(key);
				if (child != null) return child.Search(key);
			}

			throw new KeyNotFoundException();
		}

		public void Add(int key, T value)
		{
			if (key == _key)
			{
				_value = value;
			}
			else
			{
				ref var child = ref GetChild(key);
				if (child == null) child = new MyNode<T>(this, key, value);
				else child.Add(key, value);
			}
		}

		public bool Delete(int key)
		{
			if (_key == key)
			{
				MyNode<T>? replacement = null;

				if (_right == null || _left == null)
				{
					replacement = _right == null ? _left : _right;
					_top.ReplaceChild(this, replacement);
				}
				else
				{
					replacement = _right;

					if (_left != null)
					{
						while (replacement._left != null)
						{
							replacement = replacement._left;
						}
					}

					replacement._top.ReplaceChild(replacement, replacement._right);
					_top.ReplaceChild(this, replacement);
					replacement.SetChild(ref replacement._left, _left);
					replacement.SetChild(ref replacement._right, _right);
				}

				return true;
			}

			var child = GetChild(key);
			if (child != null) return child.Delete(key);
			return false;
		}

		public ref MyNode<T> GetChild(int key)
		{
			if (key > _key) return ref _right;
			else return ref _left;
		}

		private void SetChild(ref MyNode<T>? variable, MyNode<T>? value)
		{
			if (value != null) value._top = this;
			variable = value;
		}
		
		public void ReplaceChild(MyNode<T> current, MyNode<T>? next)
		{
			if (current == _right) SetChild(ref _right, next);
			else if (current == _left) SetChild(ref _left, next);
		}

		public void Display(List<string> stack)
		{
			int level = 1;
			MyNode<T> current = this;

			while (current._top is MyNode<T> top)
			{
				current = top;
				level++;
			}

			int topIndex = _top is MyNode<T> node ? node._key : 0;
			int left = _left == null ? -1 : _left._key;
			int right = _right == null ? -1 : _right._key;

			stack.Add($"{level} | {_key} ( <{left} {right}> ^ {topIndex})| {_value}");

			if (_right != null) _right.Display(stack);
			if (_left != null) _left.Display(stack);
		}
	}

	public class MyTree<T>() : IRoot<T>
	{
		public T this[int key]
		{
			get
			{
				if (_root == null) throw new KeyNotFoundException();
				else return _root.Search(key);
			}
		}

		public MyNode<T>? _root;

		public void Add(int key, T value)
		{
			if (_root == null) _root = new MyNode<T>(this, key, value);
			else _root.Add(key, value);
		}

		public ref MyNode<T> ReplaceChild(MyNode<T> child) => ref _root;

		public bool Delete(int key)
		{
			if (_root == null) return false;
			else return _root.Delete(key);
		}

		public void Display()
		{
			List<string> list = [];
			_root.Display(list);
			foreach (var node in list) Console.WriteLine(node);
		}

		public void ReplaceChild(MyNode<T> current, MyNode<T> next) => _root = next;
	}

	public interface IRoot<T>
	{
		public void ReplaceChild(MyNode<T> current, MyNode<T> next);
	}
}