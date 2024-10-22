namespace Lab6
{
	internal class Menu
	{
		public event Action<int> OnDataReceived;

		public void Input()
		{
			Console.WriteLine("Ввдеіть число:");
			int number = int.Parse(Console.ReadLine());
			OnDataReceived?.Invoke(number);
			Input();
		}
	}
}