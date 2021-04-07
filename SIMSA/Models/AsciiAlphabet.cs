using SIMSA.Resources;

namespace SIMSA.Models
{
	public class AsciiAlphabet : IAlphabet
	{
		public string Name => AppResources.ASCII;
		public int ToUnicode(int index) => ((index % 256 + 256) % 256);
		public int FromUnicode(int letter) => letter > 127 || letter < 0 ? -1 : letter;

	}
}
