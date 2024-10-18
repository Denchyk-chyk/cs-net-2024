namespace Lab5
{
	public class MyTree<T>() : INodesContainer<T>
	{
		public T this[int key]
		{
			get
			{
				if (Nodes[Side.Center] == null) throw new KeyNotFoundException();
				else return Nodes[Side.Center].Search(key);
			}
		}

		public NodesAccessor<T> Nodes
		{
			get
			{
				if (_nodes == null) _nodes = new(this);
				return _nodes;
			}
		}
		private NodesAccessor<T> _nodes;

		public void Add(int key, T value)
		{
			if (Nodes[Side.Center] == null) Nodes[Side.Center] = new MyNode<T>(key, value);
			else Nodes[Side.Center].Add(key, value);
		}

		public bool Delete(int key)
		{
			if (Nodes[Side.Center] == null) return false;
			else return Nodes[Side.Center].Delete(key);
		}
	}

	public class MyNode<T> : INodesContainer<T>
	{
		public NodesAccessor<T> Nodes => _nodes;

		public Side Side { private get; set; }
		public INodesContainer<T> Top { get; set; }

		private int _key;
		private NodesAccessor<T> _nodes;
		private T? _value;

		private MyNode() { }

		public MyNode(int key, T value)
		{
			_key = key;
			_value = value;
			_nodes = new(this);
		}

		public T Search(int key)
		{
			if (key == _key)
			{
				return _value;
			}
			else
			{
				var side = CompareKeys(key);
				if (Nodes[side] != null) return Nodes[side].Search(key);
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
				var side = CompareKeys(key);
				if (Nodes[side] == null) Nodes[side] = new MyNode<T>(key, value);
				else Nodes[side].Add(key, value);
			}
		}

		public bool Delete(int key)
		{
			if (_key == key)
			{
				MyNode<T>? replacement = null;

				if (Nodes[Side.Right] == null || Nodes[Side.Left] == null)
				{
					Top.Nodes[Side] = Nodes[Side.Right] == null ? Nodes[Side.Left] : Nodes[Side.Right];
				}
				else
				{
					replacement = Nodes[Side.Right];

					if (Nodes[Side.Left] != null)
					{
						while (replacement.Nodes[Side.Left] != null)
						{
							replacement = replacement.Nodes[Side.Left];
						}
					}

					replacement.Top.Nodes[replacement.Side] = replacement.Nodes[Side.Right];
					Top.Nodes[Side] = replacement;
					replacement.Nodes[Side.Left] = Nodes[Side.Left];
					replacement.Nodes[Side.Right] = Nodes[Side.Right];
				}

				return true;
			}

			var side = CompareKeys(key);
			if (Nodes[side] != null) return Nodes[side].Delete(key);
			return false;
		}

		private Side CompareKeys(int key) => (Side)key.CompareTo(_key);
	}

	public class NodesAccessor<T>(INodesContainer<T> container)
	{
		public MyNode<T>? this[Side side]
		{
			get
			{
				try
				{
					return _children[side];
				}
				catch (KeyNotFoundException)
				{
					return null;
				}
			}
			set
			{
				if (value == null)
				{
					_children.Remove(side);	
				}
				else
				{
					_children[side] = value;
					_children[side].Side = side;
					_children[side].Top = container;
				}
			}
		}
		
		private Dictionary<Side, MyNode<T>> _children = [];
	}

	public interface INodesContainer<T>
	{
		public NodesAccessor<T> Nodes { get; }
	}

	public enum Side
	{
		Left = -1, Center = 0, Right = 1
	}
}