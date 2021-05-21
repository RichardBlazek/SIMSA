using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace SIMSA.Models
{
	public class PlayfairText
	{
		readonly string text, key;
		public char Replaced { get; }

		string Filter(string s) => s.ToUpper().Where(c => c >= 'A' && c <= 'Z' && c != Replaced).Cat();

		string FilteredKey => Filter(key).Distinct().Cat();

		static ImmutableArray<int> Lookup(string s, string alphabet) => s.Select(c => alphabet.IndexOf(c)).ToImmutableArray();
		public override string ToString()
		{
			string f_key = FilteredKey;
			string alphabet = f_key + Filter("ABCDEFGHIJKMLNOPQRSTUVWXYZ").Where(c => !f_key.Contains(c)).Cat();
			var indices = Lookup(Filter(text), alphabet);
			var result = new StringBuilder(indices.Length);

			char Letter(int x, int y) => alphabet[x.Mod(5) + 5 * y.Mod(5)];
			string Encrypt(int x1, int y1, int x2, int y2) => y1 == y2 ? $"{Letter(x1 - 1, y1)}{Letter(x2 - 1, y2)}" : x1 == x2 ? $"{Letter(x1, y1 - 1)}{Letter(x2, y2 - 1)}" : $"{Letter(x2, y1)}{Letter(x1, y2)}";

			for (int i = 0; i < indices.Length - 1; i += 2)
			{
				_ = result.Append(Encrypt(indices[i] % 5, indices[i] / 5, indices[i + 1] % 5, indices[i + 1] / 5));
			}
			return result.ToString();
		}

		PlayfairText(string text, string key, char replaced)
		{
			this.text = text;
			this.key = key;
			Replaced = replaced;
		}
		public PlayfairText() : this("", "", 'Q') { }
		public PlayfairText WithText(string new_text) => new PlayfairText(new_text, key, Replaced);
		public PlayfairText WithKey(string new_key) => new PlayfairText(text, new_key, Replaced);
		public PlayfairText WithReplaced(char new_replaced) => new PlayfairText(text, key, new_replaced);
	}
}
