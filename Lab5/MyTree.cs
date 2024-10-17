namespace Lab5
{
	internal class MyTree<T>
	{
		public T this[int key] => _tree.ContainsKey(key) ? _tree[key]: default;

		private Dictionary<int, T> _tree = [];

		public void Add(int key, T value) =>_tree[key] = value;
		public void Delete(int key) => _tree.Remove(key);
	}
}