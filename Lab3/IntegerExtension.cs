using System.Text;

namespace Lab3
{
	internal static class IntegerExtension
	{
		private const string HexCharacters = "0123456789ABCDEF";

		public static string ToHex(this long number)
		{
			var hex = new StringBuilder();
			var negative = number < 0;
			number = Math.Abs(number);

			while (Math.Abs(number) > 0)
			{
				hex.Insert(0, HexCharacters[(int)(number % 16)]);
				number /= 16;
			}

			if (negative)
			{
				hex.Insert(0, "-");
			}

			return hex.ToString();
		}
	}
}