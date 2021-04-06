namespace SIMSA.Models
{
	public class AsciiAlphabet : IAlphabet
	{
		static int Mod(int nom, int den) => (nom % den + nom) % den;
		public string this[int index] => char.ConvertFromUtf32(Mod(index, 128));
		public int IndexOf(string letter) => letter.Length != 1 || letter[0] > 127 ? -1 : letter[0];

	}
}
