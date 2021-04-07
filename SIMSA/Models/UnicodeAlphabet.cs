using SIMSA.Resources;

namespace SIMSA.Models
{
	public class UnicodeAlphabet : IAlphabet
	{
		public string Name => AppResources.Unicode;
		public int ToUnicode(int index) => index;
		public int FromUnicode(int letter) => letter;
	}
}
