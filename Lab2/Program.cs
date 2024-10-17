using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

var array = new int[10];
for (int i = 0; i < array.Length; i++) array[i] = new Random().Next(int.MinValue, int.MaxValue / 2);
Console.WriteLine($"Початковий масив [{string.Join(", ", array)}]");
array = array.Select(x => x < 0 ? 0 : x).ToArray();
Console.WriteLine($"Невід'ємний масив [{string.Join(", ", array)}]");