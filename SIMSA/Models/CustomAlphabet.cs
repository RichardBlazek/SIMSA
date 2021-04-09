using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using SIMSA.Resources;

namespace SIMSA.Models
{
	public class CustomAlphabet : IAlphabet, IReadOnlyCollection<string>
	{
		public readonly ImmutableArray<string> Letters;
		public string Name { get; }
		public CustomAlphabet(ImmutableArray<string> letters, string name)
		{
			Letters = letters;
			Name = name;
		}

		public string this[int i] => Letters[i.Mod(Letters.Length)];
		public int IndexOf(string letter) => Letters.IndexOf(letter);

		public int Count => Letters.Length;
		public IEnumerator<string> GetEnumerator() => (Letters as IEnumerable<string>).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => (Letters as IEnumerable).GetEnumerator();

		public override string ToString() => Letters.Cat();

		public static readonly CustomAlphabet English = new CustomAlphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select(c => new string(c, 1)).ToImmutableArray(), AppResources.EnglishAlphabet);
		public static readonly CustomAlphabet Empty = new CustomAlphabet(English.Letters, AppResources.Alphabet);
	}
}
