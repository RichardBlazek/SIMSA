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
		static readonly IAlphabet zero = new UnicodeAlphabet();
		public ImmutableList<CustomAlphabet> Custom { get; }
		Alphabets(ImmutableList<CustomAlphabet> custom) => Custom = custom;

		public IAlphabet this[int i] => i == Custom.Count ? zero : Custom[i];
		public int Count => Custom.Count + 1;
		public IEnumerator<IAlphabet> GetEnumerator() => Custom.OfType<IAlphabet>().Prepend(zero).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public override string ToString() => JsonSerializer.Serialize(Custom.Select(ab => Tuple.Create(ab.Letters, ab.Name)));
		public static Alphabets Parse(string text)
		{
			var tuples = JsonSerializer.Deserialize<IEnumerable<Tuple<ImmutableArray<string>, string>>>(text);
			return new Alphabets(tuples.Select(pair => new CustomAlphabet(pair.Item1, pair.Item2)).ToImmutableList());
		}
		public static readonly Alphabets Initial = new Alphabets(ImmutableList.Create(CustomAlphabet.English));
		public Alphabets Add(CustomAlphabet alphabet) => new Alphabets(Custom.Add(alphabet));
		public Alphabets Update(int index, CustomAlphabet newAlphabet) => new Alphabets(Custom.SetItem(index, newAlphabet));
		public Alphabets Remove(int index) => new Alphabets(Custom.RemoveAt(index));
	}
}
