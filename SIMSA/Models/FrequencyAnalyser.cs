using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public static class FrequencyAnalyser
	{
		public enum Language { English, CzechDiacritics, Czech }
		public static Language Next(Language language) => (Language)(((int)language + 1) % 3);
		public static readonly ImmutableDictionary<Language, ImmutableArray<LetterFrequency>> Statistics = new Dictionary<Language, ImmutableArray<LetterFrequency>>
		{
			{
				Language.English, new[]
				{
					new LetterFrequency('A', 8.167 / 100),
					new LetterFrequency('B', 1.492 / 100),
					new LetterFrequency('C', 2.782 / 100),
					new LetterFrequency('D', 4.253 / 100),
					new LetterFrequency('E', 12.702 / 100),
					new LetterFrequency('F', 2.228 / 100),
					new LetterFrequency('G', 2.015 / 100),
					new LetterFrequency('H', 6.094 / 100),
					new LetterFrequency('I', 6.966 / 100),
					new LetterFrequency('J', 0.153 / 100),
					new LetterFrequency('K', 0.772 / 100),
					new LetterFrequency('L', 4.025 / 100),
					new LetterFrequency('M', 2.406 / 100),
					new LetterFrequency('N', 6.749 / 100),
					new LetterFrequency('O', 7.507 / 100),
					new LetterFrequency('P', 1.929 / 100),
					new LetterFrequency('Q', 0.095 / 100),
					new LetterFrequency('R', 5.987 / 100),
					new LetterFrequency('S', 6.327 / 100),
					new LetterFrequency('T', 9.056 / 100),
					new LetterFrequency('U', 2.758 / 100),
					new LetterFrequency('V', 0.978 / 100),
					new LetterFrequency('W', 2.360 / 100),
					new LetterFrequency('X', 0.150 / 100),
					new LetterFrequency('Y', 1.974 / 100),
					new LetterFrequency('Z', 0.074 / 100)
				}.ToImmutableArray()
			},
			{
				Language.CzechDiacritics, new[]
				{
					new LetterFrequency('A', 8.4548 / 100),
					new LetterFrequency('B', 1.5582 / 100),
					new LetterFrequency('C', 3.1411 / 100),
					new LetterFrequency('D', 3.6241 / 100),
					new LetterFrequency('E', 10.6751 / 100),
					new LetterFrequency('F', 0.2732 / 100),
					new LetterFrequency('G', 0.2729 / 100),
					new LetterFrequency('H', 1.8566 / 100),
					new LetterFrequency('I', 7.6227 / 100),
					new LetterFrequency('J', 2.1194 / 100),
					new LetterFrequency('K', 3.7367 / 100),
					new LetterFrequency('L', 3.8424 / 100),
					new LetterFrequency('M', 3.2267 / 100),
					new LetterFrequency('N', 6.6167 / 100),
					new LetterFrequency('O', 8.6977 / 100),
					new LetterFrequency('P', 3.4127 / 100),
					new LetterFrequency('Q', 0.0013 / 100),
					new LetterFrequency('R', 4.9136 / 100),
					new LetterFrequency('S', 5.3212 / 100),
					new LetterFrequency('T', 5.7694 / 100),
					new LetterFrequency('U', 3.9422 / 100),
					new LetterFrequency('V', 4.6616 / 100),
					new LetterFrequency('W', 0.0088 / 100),
					new LetterFrequency('X', 0.0755 / 100),
					new LetterFrequency('Y', 2.9814 / 100),
					new LetterFrequency('Z', 3.1939 / 100)
				}.ToImmutableArray()
			},
			{
				Language.Czech, new[]
				{
					new LetterFrequency('A', 6.2193 / 100),
					new LetterFrequency('Á', 2.2355 / 100),
					new LetterFrequency('B', 1.5582 / 100),
					new LetterFrequency('C', 2.1921 / 100),
					new LetterFrequency('Č', 0.9490 / 100),
					new LetterFrequency('D', 3.6019 / 100),
					new LetterFrequency('Ď', 0.0222 / 100),
					new LetterFrequency('E', 7.6952 / 100),
					new LetterFrequency('É', 1.3346 / 100),
					new LetterFrequency('Ě', 1.6453 / 100),
					new LetterFrequency('F', 0.2732 / 100),
					new LetterFrequency('G', 0.2729 / 100),
					new LetterFrequency('H', 1.8566 / 100),
					new LetterFrequency('I', 4.3528 / 100),
					new LetterFrequency('Í', 3.2699 / 100),
					new LetterFrequency('J', 2.1194 / 100),
					new LetterFrequency('K', 3.7367 / 100),
					new LetterFrequency('L', 3.8424 / 100),
					new LetterFrequency('M', 3.2267 / 100),
					new LetterFrequency('N', 6.5353 / 100),
					new LetterFrequency('Ň', 0.0814 / 100),
					new LetterFrequency('O', 8.6664 / 100),
					new LetterFrequency('Ó', 0.0313 / 100),
					new LetterFrequency('P', 3.4127 / 100),
					new LetterFrequency('Q', 0.0013 / 100),
					new LetterFrequency('R', 3.6970 / 100),
					new LetterFrequency('Ř', 1.2166 / 100),
					new LetterFrequency('S', 4.5160 / 100),
					new LetterFrequency('Š', 0.8052 / 100),
					new LetterFrequency('T', 5.7268 / 100),
					new LetterFrequency('Ť', 0.0426 / 100),
					new LetterFrequency('U', 3.1443 / 100),
					new LetterFrequency('Ú', 0.1031 / 100),
					new LetterFrequency('Ů', 0.6948 / 100),
					new LetterFrequency('V', 4.6616 / 100),
					new LetterFrequency('W', 0.0088 / 100),
					new LetterFrequency('X', 0.0755 / 100),
					new LetterFrequency('Y', 1.9093 / 100),
					new LetterFrequency('Ý', 1.0721 / 100),
					new LetterFrequency('Z', 2.1987 / 100),
					new LetterFrequency('Ž', 0.9952 / 100)
				}.ToImmutableArray()
			}
		}.ToImmutableDictionary();
		public static ImmutableArray<LetterFrequency> Analyse(string text)
		{
			var occurences = new Dictionary<char, int>();
			for (int i = 0; i < text.Length; ++i)
			{
				if (!char.IsWhiteSpace(text[i]) && !char.IsControl(text[i]))
				{
					occurences[text[i]] = occurences.GetValueOrDefault(text[i], 0) + 1;
				}
			}
			var sum = (double)occurences.Sum(pair => pair.Value);
			return occurences.Select(p => new LetterFrequency(p.Key, p.Value / sum)).ToImmutableArray();
		}
	}
}
