using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public class BrailleText : IReadOnlyList<byte>
	{
		static bool IsSet(byte value, int bit) => ((value >> (5 - bit)) & 1) == 1;
		static byte Negate(byte value, int bit) => (byte)((1 << (5 - bit)) ^ value);
		static readonly ImmutableDictionary<char, byte> LetterToBraille = new Dictionary<char, byte>
		{
			{ 'A', 0b10_00_00 },
			{ 'B', 0b10_10_00 },
			{ 'C', 0b11_00_00 },
			{ 'D', 0b11_01_00 },
			{ 'E', 0b10_01_00 },
			{ 'F', 0b11_10_00 },
			{ 'G', 0b11_11_00 },
			{ 'H', 0b10_11_00 },
			{ 'I', 0b01_10_00 },
			{ 'J', 0b01_11_00 },
			{ 'K', 0b10_00_10 },
			{ 'L', 0b10_10_10 },
			{ 'M', 0b11_00_10 },
			{ 'N', 0b11_01_10 },
			{ 'O', 0b10_01_10 },
			{ 'P', 0b11_10_10 },
			{ 'Q', 0b11_11_10 },
			{ 'R', 0b10_11_10 },
			{ 'S', 0b01_10_10 },
			{ 'T', 0b01_11_10 },
			{ 'U', 0b10_00_11 },
			{ 'V', 0b10_10_11 },
			{ 'X', 0b11_00_11 },
			{ 'Y', 0b11_01_11 },
			{ 'Z', 0b10_01_11 },
			{ 'W', 0b01_11_01 }
		}.ToImmutableDictionary();
		static readonly ImmutableDictionary<byte, char> BrailleToLetter = LetterToBraille.ToImmutableDictionary(kv => kv.Value, kv => kv.Key);

		readonly ImmutableArray<byte> letters;
		public BrailleText() => letters = ImmutableArray.Create((byte)0);
		BrailleText(ImmutableArray<byte> letters) => this.letters = letters;

		public override string ToString() => letters.Select(b => BrailleToLetter.GetValueOrDefault(b, '?')).Cat();
		public bool this[Index index, int bit] => IsSet(letters[index], bit);
		public BrailleText InvertAt(int bit) => new BrailleText(letters.SetItem(letters.Length - 1, Negate(letters[^1], bit)));
		public BrailleText Invert() => new BrailleText(letters.Select(c => (byte)(~c & 0b111111)).ToImmutableArray());
		public BrailleText Pop() => new BrailleText(letters.Length > 1 ? letters.RemoveAt(letters.Length - 1) : letters.SetItem(0, 0));
		public BrailleText Add(byte b) => new BrailleText(letters.Add(b));

		public int Count => letters.Length;
		public byte this[int index] => letters[index];
		public IEnumerator<byte> GetEnumerator() => (letters as IEnumerable<byte>).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => (letters as IEnumerable).GetEnumerator();
	}
}
