using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public class HTMLColorModel : IColorModel
	{
		public ImmutableArray<string> Names => ImmutableArray.Create("HTML");
		public string Filter(string input, int i)
		{
			static bool IsHexDigit(char c) => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F');
			return input.ToUpper().Where(IsHexDigit).Take(6).Cat().PadRight(6, '0');
		}
		static byte ParseHex(string s) => byte.Parse(s, System.Globalization.NumberStyles.HexNumber);
		public RGBColor ToRGB(IReadOnlyList<string> inputs) => new RGBColor(ParseHex(inputs[0][..2]), ParseHex(inputs[0][2..4]), ParseHex(inputs[0][4..]));
		public ImmutableArray<string> FromRGB(RGBColor color) => ImmutableArray.Create(color.ToString());
	}
}
