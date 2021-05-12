using System.Text;

namespace SIMSA.Models
{
	public class Vigenere
	{
		public string Text { get; }
		public string Key { get; }
		public bool Minus { get; }
		public Vigenere(string text = "", string key = "", bool minus = false)
		{
			Text = text;
			Key = key;
			Minus = minus;
		}

		public string DecipheredIn(IAlphabet alphabet)
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
		public Vigenere InvertSign() => new Vigenere(Text, Key, !Minus);
		public Vigenere WithText(string text) => new Vigenere(text, Key, Minus);
		public Vigenere WithKey(string key) => new Vigenere(Text, key, Minus);
	}
}
