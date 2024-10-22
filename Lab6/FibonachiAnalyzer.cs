namespace Lab6
{
	internal class FibonachiAnalyzer : NumberAnalyzer
	{
		public override void Analyze(int number)
		{
			int a = 0, b = 1, i = 1;
			do
			{
				if (a == number)
				{
					Console.WriteLine($"Число Фібоначі №{i}");
					return;
				}
				i++;
				(a, b) = (b, a + b);
			}
			while (a <= number);
			Console.WriteLine("Не число Фібоначі");
		}
	}
}