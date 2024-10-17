using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

Console.Write($"Введіть час: ");
var t = double.Parse(Console.ReadLine());
Console.WriteLine($"Швидкість: {Math.Round((3 * Math.Pow(t, 2)) - (1 / (2 * Math.Sqrt(t))), 2)}"); //v=3(t^2)-1/2√t
Console.WriteLine($"Відстань: {Math.Round(Math.Pow(t, 3) - Math.Sqrt(t), 2)}"); //S=t^3-√t