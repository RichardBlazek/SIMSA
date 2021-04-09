namespace SIMSA.Models
{
	public interface IAlphabet
	{
		string Name { get; }
		int IndexOf(string text);
		string this[int index] { get; }
	}
}
