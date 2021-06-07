using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public class HSLColorModel : IColorModel
	{
		public ImmutableArray<string> Names => ImmutableArray.Create("H", "S", "L");
		public string Filter(string input, int i) => input.Where(c => c >= '0' && c <= '9').DefaultIfEmpty('0').Cat();
		public ImmutableArray<string> FromRGB(RGBColor color)
		{
			var (chroma, hue, max, min) = ColorCalculations.ChromaHueMaxMin(color.R, color.G, color.B);
			int light = (max + min) / 2;
			int saturation = light == 0 || light == 255 ? 0 : chroma * 255 / (255 - Math.Abs(2 * light - 255));
			return ImmutableArray.Create(hue.ToString(), saturation.ToString(), light.ToString());
		}
		public RGBColor ToRGB(IReadOnlyList<string> inputs)
		{
			int h = int.Parse(inputs[0]), s = int.Parse(inputs[1]), l = int.Parse(inputs[2]);
			int chroma = s * (255 - Math.Abs(2 * l - 255)) / 255;
			return ColorCalculations.RGBColor(chroma, h, l - chroma / 2);
		}
	}
}
