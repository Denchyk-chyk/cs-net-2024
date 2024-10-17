using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

var array = new int[10];
//Генерація масиву
for (int i = 0; i < array.Length; i++) array[i] = new Random().Next(int.MinValue, int.MaxValue / 2);
Console.WriteLine($"Початковий масив [{string.Join(", ", array)}]");
//Заміна значень масиву
array = array.Select(x => Math.Max(0, x)).ToArray();
Console.WriteLine($"Невід'ємний масив [{string.Join(", ", array)}]");