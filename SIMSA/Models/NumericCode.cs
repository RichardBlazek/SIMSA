using System;
using System.Linq;

namespace SIMSA.Models
{
	public class NumericCode
	{
		public static readonly string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		static byte DigitValue(char c) => c >= '0' && c <= '9' ? (byte)(c - '0') : (byte)(c >= 'A' && c <= 'Z' ? c - 'A' + 10 : 255);
		string CodeToText(string s, IAlphabet alphabet)
		{
			if (s.Length <= 0)
			{
				return string.Empty;
			}
			int value = 0;
			for (int i = 0; i < s.Length; ++i)
			{
				value *= Radix;
				byte digit = DigitValue(s[i]);
				if (digit >= Radix)
				{
					return string.Empty;
				}
				value += digit;
			}
			return alphabet[value];
		}

		readonly string text;
		public readonly byte Radix;
		NumericCode(string txt, byte radix)
		{
			text = txt;
			Radix = radix;
		}
		public NumericCode() : this(string.Empty, 10) { }
		public static NumericCode Parse(string text, int radix) => new NumericCode(text.Where(c => c == '/' || DigitValue(c) < radix).Cat(), (byte)Math.Clamp(radix, 2, 36));

		public NumericCode Add(char c, int i) => c == '/' || DigitValue(c) < Radix ? new NumericCode(text[..i] + c + text[i..], Radix) : this;
		public NumericCode Remove(int i) => i >= 0 && i < text.Length ? new NumericCode(text[..i] + text[(i + 1)..], Radix) : this;
		public NumericCode WithRadix(byte r) => r >= 2 && r <= 36 ? new NumericCode(text.Where(c => c == '/' || DigitValue(c) < r).Cat(), r) : this;
		public NumericCode Invert() => new NumericCode(text.Select(c => c == '/' ? '/' : Digits[Radix - 1 - DigitValue(c)]).Cat(), Radix);

		public int Length => text.Length;
		public override string ToString() => text;
		public string ToLetters(IAlphabet alphabet) => text.Split('/').Select(code => CodeToText(code, alphabet)).Cat();
		public bool IsTextValid(string text) => text.All(c => c == '/' || DigitValue(c) < Radix);
	}
}
