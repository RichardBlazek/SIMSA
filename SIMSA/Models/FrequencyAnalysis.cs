using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public static class FrequencyAnalysis
	{
		public enum Language { English, CzechDiacritics, Czech }
		public static readonly ImmutableDictionary<Language, ImmutableDictionary<char, double>> Statistics = new Dictionary<Language, ImmutableDictionary<char, double>>
		{
			{
				Language.English, new Dictionary<char, double>
				{
					{ 'A', 8.167 / 100 },
					{ 'B', 1.492 / 100 },
					{ 'C', 2.782 / 100 },
					{ 'D', 4.253 / 100 },
					{ 'E', 12.702 / 100 },
					{ 'F', 2.228 / 100 },
					{ 'G', 2.015 / 100 },
					{ 'H', 6.094 / 100 },
					{ 'I', 6.966 / 100 },
					{ 'J', 0.153 / 100 },
					{ 'K', 0.772 / 100 },
					{ 'L', 4.025 / 100 },
					{ 'M', 2.406 / 100 },
					{ 'N', 6.749 / 100 },
					{ 'O', 7.507 / 100 },
					{ 'P', 1.929 / 100 },
					{ 'Q', 0.095 / 100 },
					{ 'R', 5.987 / 100 },
					{ 'S', 6.327 / 100 },
					{ 'T', 9.056 / 100 },
					{ 'U', 2.758 / 100 },
					{ 'V', 0.978 / 100 },
					{ 'W', 2.360 / 100 },
					{ 'X', 0.150 / 100 },
					{ 'Y', 1.974 / 100 },
					{ 'Z', 0.074 / 100 }
				}.ToImmutableDictionary()
			},
			{
				Language.CzechDiacritics, new Dictionary<char, double>
				{
					{ 'A', 8.4548 / 100 },
					{ 'B', 1.5582 / 100 },
					{ 'C', 3.1411 / 100 },
					{ 'D', 3.6241 / 100 },
					{ 'E', 10.6751 / 100 },
					{ 'F', 0.2732 / 100 },
					{ 'G', 0.2729 / 100 },
					{ 'H', 1.8566 / 100 },
					{ 'I', 7.6227 / 100 },
					{ 'J', 2.1194 / 100 },
					{ 'K', 3.7367 / 100 },
					{ 'L', 3.8424 / 100 },
					{ 'M', 3.2267 / 100 },
					{ 'N', 6.6167 / 100 },
					{ 'O', 8.6977 / 100 },
					{ 'P', 3.4127 / 100 },
					{ 'Q', 0.0013 / 100 },
					{ 'R', 4.9136 / 100 },
					{ 'S', 5.3212 / 100 },
					{ 'T', 5.7694 / 100 },
					{ 'U', 3.9422 / 100 },
					{ 'V', 4.6616 / 100 },
					{ 'W', 0.0088 / 100 },
					{ 'X', 0.0755 / 100 },
					{ 'Y', 2.9814 / 100 },
					{ 'Z', 3.1939 / 100 }
				}.ToImmutableDictionary()
			},
			{
				Language.Czech, new Dictionary<char, double>
				{
					{ 'A', 6.2193 / 100 },
					{ 'Á', 2.2355 / 100 },
					{ 'B', 1.5582 / 100 },
					{ 'C', 2.1921 / 100 },
					{ 'Č', 0.9490 / 100 },
					{ 'D', 3.6019 / 100 },
					{ 'Ď', 0.0222 / 100 },
					{ 'E', 7.6952 / 100 },
					{ 'É', 1.3346 / 100 },
					{ 'Ě', 1.6453 / 100 },
					{ 'F', 0.2732 / 100 },
					{ 'G', 0.2729 / 100 },
					{ 'H', 1.8566 / 100 },
					{ 'I', 4.3528 / 100 },
					{ 'Í', 3.2699 / 100 },
					{ 'J', 2.1194 / 100 },
					{ 'K', 3.7367 / 100 },
					{ 'L', 3.8424 / 100 },
					{ 'M', 3.2267 / 100 },
					{ 'N', 6.5353 / 100 },
					{ 'Ň', 0.0814 / 100 },
					{ 'O', 8.6664 / 100 },
					{ 'Ó', 0.0313 / 100 },
					{ 'P', 3.4127 / 100 },
					{ 'Q', 0.0013 / 100 },
					{ 'R', 3.6970 / 100 },
					{ 'Ř', 1.2166 / 100 },
					{ 'S', 4.5160 / 100 },
					{ 'Š', 0.8052 / 100 },
					{ 'T', 5.7268 / 100 },
					{ 'Ť', 0.0426 / 100 },
					{ 'U', 3.1443 / 100 },
					{ 'Ú', 0.1031 / 100 },
					{ 'Ů', 0.6948 / 100 },
					{ 'V', 4.6616 / 100 },
					{ 'W', 0.0088 / 100 },
					{ 'X', 0.0755 / 100 },
					{ 'Y', 1.9093 / 100 },
					{ 'Ý', 1.0721 / 100 },
					{ 'Z', 2.1987 / 100 },
					{ 'Ž', 0.9952 / 100 }
				}.ToImmutableDictionary()
			}
		}.ToImmutableDictionary();
		public static ImmutableDictionary<char, double> Analyse(string text)
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
			return occurences.ToImmutableDictionary(pair => pair.Key, pair => pair.Value / sum);
		}
	}
}
