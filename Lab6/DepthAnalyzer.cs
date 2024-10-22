namespace Lab6
{
	internal class DepthAnalyzer : NumberAnalyzer
	{
		public override void Analyze(int number)
		{
			int depth = 1;
			while (number >= 10)
			{
				depth++;
				number /= 10;
			}
			Console.WriteLine($"Кількість розрядів: {depth}");
		}
	}
}