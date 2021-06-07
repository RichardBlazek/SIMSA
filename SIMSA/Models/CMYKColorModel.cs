using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public class CMYKColorModel : IColorModel
	{
		public ImmutableArray<string> Names => ImmutableArray.Create("C", "M", "Y", "K");
		public string Filter(string input, int i) => input.Where(c => c >= '0' && c <= '9').DefaultIfEmpty('0').Cat();
		public RGBColor ToRGB(IReadOnlyList<string> inputs)
		{
			int c = int.Parse(inputs[0]), m = int.Parse(inputs[1]), y = int.Parse(inputs[2]), light = 255 - int.Parse(inputs[3]);
			return new RGBColor((255 - c) * light / 255, (255 - m) * light / 255, (255 - y) * light / 255);
		}
		public ImmutableArray<string> FromRGB(RGBColor color) => ImmutableArray.Create((255 - color.R).ToString(), (255 - color.G).ToString(), (255 - color.B).ToString(), "0");
	}
}