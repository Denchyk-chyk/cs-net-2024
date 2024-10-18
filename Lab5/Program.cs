using Lab5;
using System.Text;

public class Program
{
	public static void Main(string[] args)
	{
		Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;
		var subgroup = new MyTree<string>();

		subgroup.Add(1, "Вірста");
		subgroup.Add(5, "Нікутін");
		subgroup.Add(4, "Микитин");
		subgroup.Add(6, "Питюк");
		subgroup.Add(2, "Мацько");
		subgroup.Add(8, "Славніков");
		subgroup.Add(7, "Польнюк");
		subgroup.Add(9, "Стасюк");
		subgroup.Add(12, "Угринчук");
		subgroup.Add(10, "Токарєв");
		subgroup.Add(11, "Тріщ");
		subgroup.Add(15, "Ціник");
		subgroup.Add(14, "Хімій");
		subgroup.Add(13, "Федорчук");
		subgroup.Add(17, "Яковишин");
		subgroup.Add(3, "Мельничук");
		subgroup.Add(16, "Чурчак");

		TryGetValues(subgroup, Enumerable.Range(1, 10).ToArray());

		subgroup.Delete(9);
		subgroup.Delete(7);
		subgroup.Delete(12);
		subgroup.Delete(13);
		subgroup.Delete(15);
		
		TryGetValues(subgroup, Enumerable.Range(7, 10).ToArray());
	}

	private static void TryGetValues<T>(MyTree<T> tree, params int[] keys)
	{
		foreach (var key in keys)
		{
			try
			{
				Console.WriteLine(tree[key]);
			}
			catch
			{
				Console.WriteLine($"Ключ {key} відсутній");
			}
		}
		Console.WriteLine(new string('-', 80));
	}
}