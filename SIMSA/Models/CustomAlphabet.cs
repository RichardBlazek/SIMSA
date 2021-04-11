using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using SIMSA.Resources;

namespace SIMSA.Models
{
	public class CustomAlphabet : IAlphabet, IReadOnlyCollection<string>
	{
		public ImmutableArray<string> Letters { get; }
		public string Name { get; }
		public int ZeroIndex { get; }
		public CustomAlphabet(ImmutableArray<string> letters, string name, int zeroIndex)
		{
			Letters = letters;
			Name = name;
			ZeroIndex = zeroIndex;
		}

		public string this[int i] => Letters[(i - ZeroIndex).Mod(Letters.Length)];
		public int IndexOf(string letter) => Letters.IndexOf(letter) + ZeroIndex;

		public int Count => Letters.Length;
		public IEnumerator<string> GetEnumerator() => (Letters as IEnumerable<string>).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => (Letters as IEnumerable).GetEnumerator();

		public static readonly CustomAlphabet English = new CustomAlphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select(c => c.ToString()).ToImmutableArray(), AppResources.EnglishAlphabet, 1);
		public static readonly CustomAlphabet Empty = new CustomAlphabet(English.Letters, AppResources.Alphabet, 0);
	}
}
