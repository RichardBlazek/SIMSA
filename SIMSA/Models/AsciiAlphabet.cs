using SIMSA.Resources;

namespace SIMSA.Models
{
	public class AsciiAlphabet : IAlphabet
	{
		public string Name => AppResources.ASCII;
		public string this[int index] => char.ConvertFromUtf32((index % 256 + 256) % 256);
		public int IndexOf(string text) => text.Length == 1 && text[0] < 256 ? text[0] : -1;

	}
}
