using System.Text;

namespace SIMSA.Models
{
	public class VigenereText
	{
		public string Text { get; }
		public string Key { get; }
		public bool Minus { get; }
		readonly IAlphabet alphabet;
		public VigenereText(IAlphabet alphabet, string text = "", string key = "", bool minus = false)
		{
			this.alphabet = alphabet;
			Text = text;
			Key = key;
			Minus = minus;
		}

		public override string ToString()
		{
			if (Key.Length <= 0)
			{
				return Text;
			}
			var result = new StringBuilder(Text.Length);
			foreach (var (textPart, keyPart) in Text.DivideToUnicodeChars().Zip(Key.DivideToUnicodeChars().Forever()))
			{
				int textCode = alphabet.IndexOf(textPart), keyCode = alphabet.IndexOf(keyPart);
				_ = result.Append(textCode == -1 || keyCode == -1 ? textPart : alphabet[textCode + keyCode * (Minus ? -1 : 1)]);
			}
			return result.ToString();
		}
		public VigenereText InvertSign() => new VigenereText(alphabet, Text, Key, !Minus);
		public VigenereText WithText(string text) => new VigenereText(alphabet, text, Key, Minus);
		public VigenereText WithKey(string key) => new VigenereText(alphabet, Text, key, Minus);
		public VigenereText WithAlphabet(IAlphabet newAlphabet) => new VigenereText(newAlphabet, Text, Key, Minus);
		public override bool Equals(object obj) => obj is VigenereText v && v.Text == Text && v.Key == Key && v.Minus == Minus;
	}
}
