using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public class HSLColorModel : IColorModel
	{
		public ImmutableArray<string> Names => ImmutableArray.Create("H", "S", "L");
		public bool NumbersOnly => true;
		public ImmutableArray<string> ToStrings(RGBColor color)
		{
			var (chroma, hue, max, min) = ColorCalculations.ChromaHueMaxMin(color.R, color.G, color.B);
			int light = (max + min) / 2;
			int saturation = light == 0 || light == 255 ? 0 : chroma * 255 / (255 - Math.Abs(2 * light - 255));
			return ImmutableArray.Create(hue.ToString(), saturation.ToString(), light.ToString());
		}
		public (ImmutableArray<string>, RGBColor) Parse(IReadOnlyList<string> inputs)
		{
			var texts = inputs.Align(3, "0").Select(s => s.RemoveNonDigits()).ToImmutableArray();
			int h = texts[0].ParseInt() % 360, s = texts[1].ParseInt() % 256, l = texts[2].ParseInt() % 256;
			int chroma = s * (255 - Math.Abs(2 * l - 255)) / 255;
			return (texts, ColorCalculations.RGBColor(chroma, h, l - chroma / 2));
		}
	}
}
