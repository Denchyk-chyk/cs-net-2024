using Lab5;
using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

var group = new MyTree<string>();
group.Add(1, "Вірста");
group.Add(10, "Ковбас");
group.Add(29, "Хімій");

Console.WriteLine(group[1]);
Console.WriteLine(group[29]);

group.Delete(29);

Console.WriteLine(group[29]);
Console.WriteLine(group[10]);