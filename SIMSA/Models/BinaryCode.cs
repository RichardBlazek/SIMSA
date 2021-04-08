using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace SIMSA.Models
{
	public class BinaryCode
	{
        readonly static ImmutableDictionary<char, string> LetterToMorse = new Dictionary<char, string>
        {
            {'A' , "01"},
            {'B' , "1000"},
            {'C' , "1010"},
            {'D' , "100"},
            {'E' , "0"},
            {'F' , "0010"},
            {'G' , "110"},
            {'H' , "0000"},
            {'I' , "00"},
            {'J' , "0111"},
            {'K' , "101"},
            {'L' , "0100"},
            {'M' , "11"},
            {'N' , "10"},
            {'O' , "111"},
            {'P' , "0110"},
            {'Q' , "1101"},
            {'R' , "010"},
            {'S' , "000"},
            {'T' , "1"},
            {'U' , "001"},
            {'V' , "0001"},
            {'W' , "011"},
            {'X' , "1001"},
            {'Y' , "1011"},
            {'Z' , "1100"},
            {'0' , "11111"},
            {'1' , "01111"},
            {'2' , "00111"},
            {'3' , "00011"},
            {'4' , "00001"},
            {'5' , "00000"},
            {'6' , "10000"},
            {'7' , "11000"},
            {'8' , "11100"},
            {'9' , "11110"},
        }.ToImmutableDictionary();
        readonly static ImmutableDictionary<string, char> MorseToLetter = LetterToMorse.ToImmutableDictionary(kv => kv.Value, kv => kv.Key);

        readonly string text;
		public BinaryCode(string txt = "") => text = txt;
        public BinaryCode Add(char c, int i) => c == '0' || c == '1' || c == '|' ? new BinaryCode(text[..i] + c + text[i..]) : this;
        public BinaryCode Remove(int i) => text.Length > i && i >= 0 ? new BinaryCode(text[..i] + text[(i + 1)..]) : this;
        public BinaryCode Invert() => new BinaryCode(text.Replace('0', '*').Replace('1', '0').Replace('*', '1'));

        public int Length => text.Length;
        public override string ToString() => text;
        public string ToMorse() => text.Replace('0', '\u2022').Replace('1', '\u2013');
        public string ToLettersFromMorse() => string.Join("", text.Split('|').Where(word => word.Length > 0).Select(word => MorseToLetter.GetValueOrDefault(word, '?')));
    }
}
