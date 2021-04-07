namespace SIMSA.Models
{
	public interface IAlphabet
	{
		string Name { get; }
		int FromUnicode(int utf32);
		int ToUnicode(int index);
	}
}
