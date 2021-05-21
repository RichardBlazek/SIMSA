using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public class MorseText
	{
		static readonly ImmutableDictionary<char, string> LetterToMorse = new Dictionary<char, string>
		{
			{'A', "\u2022\u2013"},
			{'B', "\u2013\u2022\u2022\u2022"},
			{'C', "\u2013\u2022\u2013\u2022"},
			{'D', "\u2013\u2022\u2022"},
			{'E', "\u2022"},
			{'F', "\u2022\u2022\u2013\u2022"},
			{'G', "\u2013\u2013\u2022"},
			{'H', "\u2022\u2022\u2022\u2022"},
			{'I', "\u2022\u2022"},
			{'J', "\u2022\u2013\u2013\u2013"},
			{'K', "\u2013\u2022\u2013"},
			{'L', "\u2022\u2013\u2022\u2022"},
			{'M', "\u2013\u2013"},
			{'N', "\u2013\u2022"},
			{'O', "\u2013\u2013\u2013"},
			{'P', "\u2022\u2013\u2013\u2022"},
			{'Q', "\u2013\u2013\u2022\u2013"},
			{'R', "\u2022\u2013\u2022"},
			{'S', "\u2022\u2022\u2022"},
			{'T', "\u2013"},
			{'U', "\u2022\u2022\u2013"},
			{'V', "\u2022\u2022\u2022\u2013"},
			{'W', "\u2022\u2013\u2013"},
			{'X', "\u2013\u2022\u2022\u2013"},
			{'Y', "\u2013\u2022\u2013\u2013"},
			{'Z', "\u2013\u2013\u2022\u2022"},
			{'0', "\u2013\u2013\u2013\u2013\u2013"},
			{'1', "\u2022\u2013\u2013\u2013\u2013"},
			{'2', "\u2022\u2022\u2013\u2013\u2013"},
			{'3', "\u2022\u2022\u2022\u2013\u2013"},
			{'4', "\u2022\u2022\u2022\u2022\u2013"},
			{'5', "\u2022\u2022\u2022\u2022\u2022"},
			{'6', "\u2013\u2022\u2022\u2022\u2022"},
			{'7', "\u2013\u2013\u2022\u2022\u2022"},
			{'8', "\u2013\u2013\u2013\u2022\u2022"},
			{'9', "\u2013\u2013\u2013\u2013\u2022"},
			{'.', "\u2022\u2013\u2022\u2013\u2022\u2013"},
			{',', "\u2013\u2013\u2022\u2022\u2013\u2013"},
			{'?', "\u2022\u2022\u2013\u2013\u2022\u2022"},
			{'\'', "\u2022\u2013\u2013\u2013\u2013\u2022"},
			{'/', "\u2013\u2022\u2022\u2013\u2022"},
			{'(', "\u2013\u2022\u2013\u2013\u2022"},
			{')', "\u2013\u2022\u2013\u2013\u2022\u2013"},
			{':', "\u2013\u2013\u2013\u2022\u2022\u2022"},
			{'=', "\u2013\u2022\u2022\u2022\u2013"},
			{'+', "\u2022\u2013\u2022\u2013\u2022"},
			{'-', "\u2013\u2022\u2022\u2022\u2022\u2013"},
			{'"', "\u2022\u2013\u2022\u2022\u2013\u2022"}
		}.ToImmutableDictionary();
		static readonly ImmutableDictionary<string, char> MorseToLetter = LetterToMorse.ToImmutableDictionary(kv => kv.Value, kv => kv.Key);

		public string Text { get; }
		public MorseText() : this(string.Empty) { }

		MorseText(string text) => Text = text;
		public static MorseText Parse(string text) => new MorseText(text.Where(c => c == '\u2022' || c == '\u2013' || c == '/').Cat());
		public MorseText Add(char c, int i) => c == '\u2022' || c == '\u2013' || c == '/' ? new MorseText(Text[..i] + c + Text[i..]) : this;
		public MorseText Remove(int i) => Text.Length > i && i >= 0 ? new MorseText(Text[..i] + Text[(i + 1)..]) : this;
		public MorseText Invert() => new MorseText(Text.Replace('\u2022', '%').Replace('\u2013', '\u2022').Replace('%', '\u2013'));

		public int Length => Text.Length;
		public override string ToString() => Text.Split('/').Where(word => word.Length > 0).Select(word => MorseToLetter.GetValueOrDefault(word, '?')).Cat();
	}
}
