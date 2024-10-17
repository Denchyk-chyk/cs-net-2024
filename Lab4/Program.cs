using Lab4;
using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

IWeapon weapon = new Weapon(23), sword = new Sword(36);
weapon.Attack();
sword.Attack();