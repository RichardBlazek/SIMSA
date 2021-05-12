using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public class Braille : IReadOnlyList<byte>
	{
		static bool IsSet(byte value, int bit) => ((value >> (5 - bit)) & 1) == 1;
		static byte Negate(byte value, int bit) => (byte)((1 << (5 - bit)) ^ value);

		static readonly ImmutableDictionary<byte, char> BrailleToLetter = new Dictionary<byte, char>
		{
			{0b10_00_00, 'A'},
			{0b10_10_00, 'B'},
			{0b11_00_00, 'C'},
			{0b11_01_00, 'D'},
			{0b10_01_00, 'E'},
			{0b11_10_00, 'F'},
			{0b11_11_00, 'G'},
			{0b10_11_00, 'H'},
			{0b01_10_00, 'I'},
			{0b01_11_00, 'J'},
			{0b10_00_10, 'K'},
			{0b10_10_10, 'L'},
			{0b11_00_10, 'M'},
			{0b11_01_10, 'N'},
			{0b10_01_10, 'O'},
			{0b11_10_10, 'P'},
			{0b11_11_10, 'Q'},
			{0b10_11_10, 'R'},
			{0b01_10_10, 'S'},
			{0b01_11_10, 'T'},
			{0b10_00_11, 'U'},
			{0b10_10_11, 'V'},
			{0b11_00_11, 'X'},
			{0b11_01_11, 'Y'},
			{0b10_01_11, 'Z'},
			{0b01_11_01, 'W'},
			{0b10_11_11, 'W'}
		}.ToImmutableDictionary();
		readonly ImmutableArray<byte> letters;
		public Braille() => letters = ImmutableArray.Create((byte)0);
		Braille(ImmutableArray<byte> letters) => this.letters = letters;

		public override string ToString() => letters.Select(b => BrailleToLetter.GetValueOrDefault(b, '?')).Cat();
		public bool this[Index index, int bit] => IsSet(letters[index], bit);
		public Braille InvertAt(int bit) => new Braille(letters.SetItem(letters.Length - 1, Negate(letters[^1], bit)));
		public Braille Invert() => new Braille(letters.Select(c => (byte)(~c & 0b111111)).ToImmutableArray());
		public Braille Pop() => new Braille(letters.Length > 1 ? letters.RemoveAt(letters.Length - 1) : letters.SetItem(0, 0));
		public Braille Add(byte b) => new Braille(letters.Add(b));

		public int Count => letters.Length;
		public byte this[int index] => letters[index];
		public IEnumerator<byte> GetEnumerator() => (letters as IEnumerable<byte>).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => (letters as IEnumerable).GetEnumerator();
	}
}
