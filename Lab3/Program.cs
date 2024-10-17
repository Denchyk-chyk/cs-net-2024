using Lab3;
using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

Console.Write($"Введіть десяткове число: ");
Console.WriteLine($"Шістадцяткове представлення: {int.Parse(Console.ReadLine()).ToHex()}");