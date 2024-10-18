using System.Text;

namespace Lab3
{
	internal static class IntegerExtension
	{
		private const string HexCharacters = "0123456789ABCDEF";

		public static string ToHex(this ulong number)
		{
			var hex = new StringBuilder();

			while (number > 0)
			{
				hex.Insert(0, HexCharacters[(int)(number % 16)]);
				number /= 16;
			}

			return hex.ToString();
		}
	}
}