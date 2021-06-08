using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public class HTMLColorModel : IColorModel
	{
		public ImmutableArray<string> Names => ImmutableArray.Create("HTML");
		public bool NumbersOnly => false;
		string Filter(string input) => input.ToUpper().Where(c => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F')).Cat();
		static byte ParseHex(string s) => byte.Parse(s, System.Globalization.NumberStyles.HexNumber);
		public (ImmutableArray<string>, RGBColor) Parse(IReadOnlyList<string> inputs)
		{
			var input = Filter(inputs.FirstOrDefault() ?? string.Empty);
			return (ImmutableArray.Create(input), input.Length switch
			{
				3 => new RGBColor(ParseHex(input[..1]) * 17, ParseHex(input[1..2]), ParseHex(input[2..]) * 17),
				6 => new RGBColor(ParseHex(input[..2]), ParseHex(input[2..4]), ParseHex(input[4..])),
				_ => new RGBColor(0, 0, 0),
			});
		}
		public ImmutableArray<string> ToStrings(RGBColor color) => ImmutableArray.Create(color.ToString());
	}
}
