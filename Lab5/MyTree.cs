namespace Lab5
{
	internal class MyTree<T>
	{
		public T this[int key]
		{
			get
			{
				T value = default;
				
				try { value = _tree[key]; }
				catch (KeyNotFoundException ex) { Console.WriteLine($"Відсутній ключ {key}"); }
				
				return value;
			}
		}

		private Dictionary<int, T> _tree = [];

		public void Add(int key, T value) =>_tree[key] = value;
		public void Delete(int key) => _tree.Remove(key);
	}
}