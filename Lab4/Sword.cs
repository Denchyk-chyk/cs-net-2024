namespace Lab4
{
	internal class Sword(int damage) : Weapon(damage)
	{
		public override void Attack() => Console.WriteLine($"Нанесено удар: -{Damage / 2}");
	}
}