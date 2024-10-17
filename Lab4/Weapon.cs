namespace Lab4
{
	internal class Weapon(int damage) : IWeapon
	{
		protected int Damage { get; private set; } = damage;

		public virtual void Attack() => Console.WriteLine($"Здійснено атаку: -{Damage}");
	}
}