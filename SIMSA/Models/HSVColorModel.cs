using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public class HSVColorModel : IColorModel
	{
		public ImmutableArray<string> Names => ImmutableArray.Create("H", "S", "V");
		public string Filter(string input, int i) => input.Where(c => c >= '0' && c <= '9').DefaultIfEmpty('0').Cat();
		public ImmutableArray<string> FromRGB(RGBColor color)
		{
			var (chroma, hue, max, _) = ColorCalculations.ChromaHueMaxMin(color.R, color.G, color.B);
			int saturation = max == 0 ? 0 : chroma * 255 / max;
			return ImmutableArray.Create(hue.ToString(), saturation.ToString(), max.ToString());
		}
		public RGBColor ToRGB(IReadOnlyList<string> inputs)
		{
			int h = int.Parse(inputs[0]), s = int.Parse(inputs[1]), v = int.Parse(inputs[2]);
			int chroma = v * s / 255;
			return ColorCalculations.RGBColor(chroma, h, v - chroma);
		}
	}
}
