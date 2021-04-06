namespace SIMSA.Models
{
	public interface IAlphabet
	{
		string this[int i] { get; }
		int IndexOf(string letter);
	}
}
