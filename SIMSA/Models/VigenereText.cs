using System.Text;

namespace SIMSA.Models
{
	public class VigenereText
	{
		public string Text { get; }
		public string Key { get; }
		public VigenereText(string text = "", string key = "")
		{
			Text = text;
			Key = key;
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
				_ = result.Append(textCode == -1 || keyCode == -1 ? textPart : alphabet[textCode + keyCode]);
			}
			return result.ToString();
		}
		public VigenereText InvertKey(IAlphabet alphabet)
		{
			var result = new StringBuilder(Key.Length);
			foreach (string part in Key.DivideToUnicodeChars())
			{
				int code = alphabet.IndexOf(part);
				_ = result.Append(code == -1 ? part : alphabet[^code]);
			}
			return new VigenereText(Text, result.ToString());
		}
	}
}
