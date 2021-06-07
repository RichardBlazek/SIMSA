using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SIMSA.Models
{
	public class RGBColorModel : IColorModel
	{
		public ImmutableArray<string> Names => ImmutableArray.Create("R", "G", "B");
		public string Filter(string input, int i) => input.Where(c => c >= '0' && c <= '9').DefaultIfEmpty('0').Cat();
		public RGBColor ToRGB(IReadOnlyList<string> inputs) => new RGBColor(int.Parse(inputs[0]), int.Parse(inputs[1]), int.Parse(inputs[2]));
		public ImmutableArray<string> FromRGB(RGBColor color) => ImmutableArray.Create(color.R.ToString(), color.G.ToString(), color.B.ToString());
	}
}
