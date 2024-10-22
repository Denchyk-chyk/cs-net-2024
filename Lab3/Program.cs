using Lab3;
using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

Console.Write($"Введіть десяткове число: ");
var number = long.Parse(Console.ReadLine());
var hex = number.ToHex();
Console.WriteLine($"Шістадцяткове представлення: {hex}");