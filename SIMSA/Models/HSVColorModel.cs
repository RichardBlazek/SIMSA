using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public class HSVColorModel : IColorModel
	{
		public ImmutableArray<string> Names => ImmutableArray.Create("H", "S", "V");
		public bool NumbersOnly => true;
		public ImmutableArray<string> ToStrings(RGBColor color)
		{
			var (chroma, hue, max, _) = ColorCalculations.ChromaHueMaxMin(color.R, color.G, color.B);
			int saturation = max == 0 ? 0 : chroma * 255 / max;
			return ImmutableArray.Create(hue.ToString(), saturation.ToString(), max.ToString());
		}
		public (ImmutableArray<string>, RGBColor) Parse(IReadOnlyList<string> inputs)
		{
			var texts = inputs.Align(3, "0").Select(s => s.RemoveNonDigits()).ToImmutableArray();
			int h = texts[0].ParseInt() % 360, s = texts[1].ParseInt() % 256, v = texts[2].ParseInt() % 256;
			int chroma = v * s / 255;
			return (texts, ColorCalculations.RGBColor(chroma, h, v - chroma));
		}
	}
}
