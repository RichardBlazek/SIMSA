namespace SIMSA.Models
{
	public class UnicodeAlphabet : IAlphabet
	{
		public string this[int index] => char.ConvertFromUtf32(index);
		public int IndexOf(string letter) => char.ConvertToUtf32(letter, 0);
	}
}
