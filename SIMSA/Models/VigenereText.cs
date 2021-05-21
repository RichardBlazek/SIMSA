using System.Text;

namespace SIMSA.Models
{
	public class VigenereText
	{
		public string Text { get; }
		public string Key { get; }
		public bool Minus { get; }
		public VigenereText(string text = "", string key = "", bool minus = false)
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
		public VigenereText InvertSign() => new VigenereText(Text, Key, !Minus);
		public VigenereText WithText(string text) => new VigenereText(text, Key, Minus);
		public VigenereText WithKey(string key) => new VigenereText(Text, key, Minus);
	}
}
