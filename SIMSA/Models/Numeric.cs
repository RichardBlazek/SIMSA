﻿using System;
using System.Linq;

namespace SIMSA.Models
{
	public class Numeric
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

		Numeric(string txt, byte radix)
		{
			text = txt;
			Radix = radix;
		}
		public Numeric() : this(string.Empty, 10) { }
		public static Numeric Parse(string text, int radix) => new Numeric(text.Where(c => c == ',' || DigitValue(c) < radix).Cat(), (byte)Math.Clamp(radix, 2, 36));

		public Numeric Add(char c, int i) => c == ',' || DigitValue(c) < Radix ? new Numeric(text[..i] + c + text[i..], Radix) : this;
		public Numeric Remove(int i) => i >= 0 && i < text.Length ? new Numeric(text[..i] + text[(i + 1)..], Radix) : this;
		public Numeric WithRadix(byte r) => r >= 2 && r <= 36 ? new Numeric(text.Where(c => c == ',' || DigitValue(c) < r).Cat(), r) : this;
		public Numeric Invert() => new Numeric(text.Select(c => c == ',' ? ',' : Digits[Radix - 1 - DigitValue(c)]).Cat(), Radix);

		public int Length => text.Length;
		public override string ToString() => text;
		public string ToLetters(IAlphabet alphabet) => text.Split(',').Select(code => CodeToText(code, alphabet)).Cat();
		public bool IsTextValid(string text) => text.All(c => c == ',' || DigitValue(c) < Radix);
	}
}