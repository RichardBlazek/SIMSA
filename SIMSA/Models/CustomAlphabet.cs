using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace SIMSA.Models
{
	public class CustomAlphabet : IAlphabet, IReadOnlyList<string>
	{
		public readonly ImmutableArray<string> Letters;
		public readonly string Name;
		public CustomAlphabet(ImmutableArray<string> letters, string name)
		{
			Letters = letters;
			Name = name;
		}

		public string this[int i] => Letters[i];
		public int IndexOf(string letter) => Letters.IndexOf(letter);

		public int Count => Letters.Length;
		public IEnumerator<string> GetEnumerator() => (Letters as IEnumerable<string>).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => (Letters as IEnumerable).GetEnumerator();
	}
}
