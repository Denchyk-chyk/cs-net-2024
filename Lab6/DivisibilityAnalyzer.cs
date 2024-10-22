namespace Lab6
{
	internal class DivisibilityAnalyzer : NumberAnalyzer
	{
		public override void Analyze(int number)
		{
			List<int> dividers = [];
			for (int i = 2; i < number; i++)
			{
				if (number % i == 0) dividers.Add(i);
			}
			if (dividers.Count > 0)
			{
				Console.WriteLine($"Число ділиться на {string.Join(", ", dividers)}");
			}
			else
			{
				Console.WriteLine("Число просте");
			}
		}
	}
}