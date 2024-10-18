using Lab5;

namespace Tester
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCase]
		public void Test1()
		{
			var tree = new MyTree<double>();
			tree.Add(1, default);
			ref var left = ref tree._root.GetChild(2);
			left = new MyNode<double>(left, 2, 12);
			Assert.That(tree._root._right._value, Is.EqualTo(12));
		}
	}
}