using SIMSA.Resources;

namespace SIMSA.Models
{
	public class UnicodeAlphabet : IAlphabet
	{
		public string Name => AppResources.Unicode;
		public string this[int i] => i < 0x10FFFF && !(i >= 0xD800 && i <= 0x0DFFF) ? char.ConvertFromUtf32(i) : string.Empty;
		public int IndexOf(string text) => text.Length == 1 || (text.Length == 2 && char.IsHighSurrogate(text[0])) ? char.ConvertToUtf32(text, 0) : -1;
	}
}
