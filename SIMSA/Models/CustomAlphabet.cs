using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using SIMSA.Resources;

namespace SIMSA.Models
{
	public class CustomAlphabet : IAlphabet, IReadOnlyList<int>
	{
		public readonly ImmutableArray<int> Letters;
		public string Name { get; }
		public CustomAlphabet(ImmutableArray<int> letters, string name)
		{
			Letters = letters;
			Name = name;
		}
		public CustomAlphabet(string letters, string name) : this(ToUTF32(letters), name) { }

		public int ToUnicode(int i) => Letters[i];
		public int FromUnicode(int letter) => Letters.IndexOf(letter);

		public int Count => Letters.Length;
		public int this[int index] => Letters[index];
		public IEnumerator<int> GetEnumerator() => (Letters as IEnumerable<int>).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => (Letters as IEnumerable).GetEnumerator();

		static ImmutableArray<int> ToUTF32(string str)
		{
			var result = ImmutableArray.CreateBuilder<int>(str.Length);
			for (int i = 0; i < str.Length; ++i)
			{
				if (char.IsHighSurrogate(str[i]) && i + 1 < str.Length)
				{
					result.Add(char.ConvertToUtf32(str[i], str[i + 1]));
					++i;
				}
				else
				{
					result.Add(str[i]);
				}
			}
			return result.ToImmutable();
		}
		public override string ToString() => string.Join("", Letters.Select(utf32 => char.ConvertFromUtf32(utf32)));

		public static readonly CustomAlphabet English = new CustomAlphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select(c => (int)c).ToImmutableArray(), AppResources.EnglishAlphabet);
		public static readonly CustomAlphabet Empty = new CustomAlphabet(ImmutableArray.Create(65, 66, 67), AppResources.Alphabet);
	}
}
