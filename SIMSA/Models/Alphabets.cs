using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public class Alphabets : IReadOnlyList<IAlphabet>
	{
		static readonly AsciiAlphabet zero = new AsciiAlphabet();
		static readonly UnicodeAlphabet one = new UnicodeAlphabet();
		readonly ImmutableList<CustomAlphabet> custom;
		public Alphabets(ImmutableList<CustomAlphabet> custom) => this.custom = custom;

		public IAlphabet this[int i] => i switch { 0 => zero, 1 => one, _ => custom[i - 2] };
		public int Count => custom.Count + 2;
		public IEnumerator<IAlphabet> GetEnumerator() => new IAlphabet[] { zero, one }.Concat(custom).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
