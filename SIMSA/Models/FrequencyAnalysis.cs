using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public static class FrequencyAnalysis
	{
		public static readonly ImmutableDictionary<char, double> English = new[]
		{
			KeyValuePair.Create('A', 8.167 / 100),
			KeyValuePair.Create('B', 1.492 / 100),
			KeyValuePair.Create('C', 2.782 / 100),
			KeyValuePair.Create('D', 4.253 / 100),
			KeyValuePair.Create('E', 12.702 / 100),
			KeyValuePair.Create('F', 2.228 / 100),
			KeyValuePair.Create('G', 2.015 / 100),
			KeyValuePair.Create('H', 6.094 / 100),
			KeyValuePair.Create('I', 6.966 / 100),
			KeyValuePair.Create('J', 0.153 / 100),
			KeyValuePair.Create('K', 0.772 / 100),
			KeyValuePair.Create('L', 4.025 / 100),
			KeyValuePair.Create('M', 2.406 / 100),
			KeyValuePair.Create('N', 6.749 / 100),
			KeyValuePair.Create('O', 7.507 / 100),
			KeyValuePair.Create('P', 1.929 / 100),
			KeyValuePair.Create('Q', 0.095 / 100),
			KeyValuePair.Create('R', 5.987 / 100),
			KeyValuePair.Create('S', 6.327 / 100),
			KeyValuePair.Create('T', 9.056 / 100),
			KeyValuePair.Create('U', 2.758 / 100),
			KeyValuePair.Create('V', 0.978 / 100),
			KeyValuePair.Create('W', 2.360 / 100),
			KeyValuePair.Create('X', 0.150 / 100),
			KeyValuePair.Create('Y', 1.974 / 100),
			KeyValuePair.Create('Z', 0.074 / 100)
		}.ToImmutableDictionary();
		public static readonly ImmutableDictionary<char, double> Czech = new[]
		{
			KeyValuePair.Create('A', 8.4548 / 100),
			KeyValuePair.Create('B', 1.5582 / 100),
			KeyValuePair.Create('C', 3.1411 / 100),
			KeyValuePair.Create('D', 3.6241 / 100),
			KeyValuePair.Create('E', 10.6751 / 100),
			KeyValuePair.Create('F', 0.2732 / 100),
			KeyValuePair.Create('G', 0.2729 / 100),
			KeyValuePair.Create('H', 1.8566 / 100),
			KeyValuePair.Create('I', 7.6227 / 100),
			KeyValuePair.Create('J', 2.1194 / 100),
			KeyValuePair.Create('K', 3.7367 / 100),
			KeyValuePair.Create('L', 3.8424 / 100),
			KeyValuePair.Create('M', 3.2267 / 100),
			KeyValuePair.Create('N', 6.6167 / 100),
			KeyValuePair.Create('O', 8.6977 / 100),
			KeyValuePair.Create('P', 3.4127 / 100),
			KeyValuePair.Create('Q', 0.0013 / 100),
			KeyValuePair.Create('R', 4.9136 / 100),
			KeyValuePair.Create('S', 5.3212 / 100),
			KeyValuePair.Create('T', 5.7694 / 100),
			KeyValuePair.Create('U', 3.9422 / 100),
			KeyValuePair.Create('V', 4.6616 / 100),
			KeyValuePair.Create('W', 0.0088 / 100),
			KeyValuePair.Create('X', 0.0755 / 100),
			KeyValuePair.Create('Y', 2.9814 / 100),
			KeyValuePair.Create('Z', 3.1939 / 100)
		}.ToImmutableDictionary();
		public static readonly ImmutableDictionary<char, double> CzechDiacritics = new[]
		{
			KeyValuePair.Create('A', 6.2193 / 100),
			KeyValuePair.Create('Á', 2.2355 / 100),
			KeyValuePair.Create('B', 1.5582 / 100),
			KeyValuePair.Create('C', 2.1921 / 100),
			KeyValuePair.Create('Č', 0.9490 / 100),
			KeyValuePair.Create('D', 3.6019 / 100),
			KeyValuePair.Create('Ď', 0.0222 / 100),
			KeyValuePair.Create('E', 7.6952 / 100),
			KeyValuePair.Create('É', 1.3346 / 100),
			KeyValuePair.Create('Ě', 1.6453 / 100),
			KeyValuePair.Create('F', 0.2732 / 100),
			KeyValuePair.Create('G', 0.2729 / 100),
			KeyValuePair.Create('H', 1.8566 / 100),
			KeyValuePair.Create('I', 4.3528 / 100),
			KeyValuePair.Create('Í', 3.2699 / 100),
			KeyValuePair.Create('J', 2.1194 / 100),
			KeyValuePair.Create('K', 3.7367 / 100),
			KeyValuePair.Create('L', 3.8424 / 100),
			KeyValuePair.Create('M', 3.2267 / 100),
			KeyValuePair.Create('N', 6.5353 / 100),
			KeyValuePair.Create('Ň', 0.0814 / 100),
			KeyValuePair.Create('O', 8.6664 / 100),
			KeyValuePair.Create('Ó', 0.0313 / 100),
			KeyValuePair.Create('P', 3.4127 / 100),
			KeyValuePair.Create('Q', 0.0013 / 100),
			KeyValuePair.Create('R', 3.6970 / 100),
			KeyValuePair.Create('Ř', 1.2166 / 100),
			KeyValuePair.Create('S', 4.5160 / 100),
			KeyValuePair.Create('Š', 0.8052 / 100),
			KeyValuePair.Create('T', 5.7268 / 100),
			KeyValuePair.Create('Ť', 0.0426 / 100),
			KeyValuePair.Create('U', 3.1443 / 100),
			KeyValuePair.Create('Ú', 0.1031 / 100),
			KeyValuePair.Create('Ů', 0.6948 / 100),
			KeyValuePair.Create('V', 4.6616 / 100),
			KeyValuePair.Create('W', 0.0088 / 100),
			KeyValuePair.Create('X', 0.0755 / 100),
			KeyValuePair.Create('Y', 1.9093 / 100),
			KeyValuePair.Create('Ý', 1.0721 / 100),
			KeyValuePair.Create('Z', 2.1987 / 100),
			KeyValuePair.Create('Ž', 0.9952 / 100)
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
