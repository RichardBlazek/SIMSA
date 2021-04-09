using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;

namespace SIMSA.Models
{
	public class Alphabets : IReadOnlyList<IAlphabet>
	{
		static readonly AsciiAlphabet zero = new AsciiAlphabet();
		static readonly UnicodeAlphabet one = new UnicodeAlphabet();
		public readonly ImmutableList<CustomAlphabet> Custom;
		Alphabets(ImmutableList<CustomAlphabet> custom) => Custom = custom;

		public IAlphabet this[int i] => i switch { 0 => zero, 1 => one, _ => Custom[i - 2] };
		public int Count => Custom.Count + 2;
		public IEnumerator<IAlphabet> GetEnumerator() => new IAlphabet[] { zero, one }.Concat(Custom).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public override string ToString() => JsonSerializer.Serialize(Custom.Select(ab => Tuple.Create(ab.Name, ab.Letters)));
		public static Alphabets Parse(string text)
		{
			var tuples = JsonSerializer.Deserialize<IEnumerable<Tuple<string, ImmutableArray<string>>>>(text);
			return new Alphabets(tuples.Select(pair => new CustomAlphabet(pair.Item2, pair.Item1)).ToImmutableList());
		}
		public static readonly Alphabets Initial = new Alphabets(ImmutableList.Create(CustomAlphabet.English));
		public Alphabets Add(CustomAlphabet alphabet) => new Alphabets(Custom.Add(alphabet));
		public Alphabets Update(int index, CustomAlphabet newAlphabet) => new Alphabets(Custom.SetItem(index, newAlphabet));
		public Alphabets Remove(int index) => new Alphabets(Custom.RemoveAt(index));
	}
}
