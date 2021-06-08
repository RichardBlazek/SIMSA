﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public class CMYKColorModel : IColorModel
	{
		public ImmutableArray<string> Names => ImmutableArray.Create("C", "M", "Y", "K");
		public bool NumbersOnly => true;
		public (ImmutableArray<string>, RGBColor) Parse(IReadOnlyList<string> inputs)
		{
			var texts = inputs.Align(4, "0").Select(s => s.RemoveNonDigits()).ToImmutableArray();
			int c = texts[0].ParseInt(), m = texts[1].ParseInt(), y = texts[2].ParseInt(), light = 255 - texts[3].ParseInt();
			return (texts, new RGBColor((255 - c) * light / 255, (255 - m) * light / 255, (255 - y) * light / 255));
		}
		public ImmutableArray<string> ToStrings(RGBColor color) => ImmutableArray.Create((255 - color.R).ToString(), (255 - color.G).ToString(), (255 - color.B).ToString(), "0");
	}
}