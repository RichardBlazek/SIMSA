using System.Collections.Generic;
using System.Collections.Immutable;

namespace SIMSA.Models
{
	public interface IColorModel
	{
		ImmutableArray<string> Names { get; }
		string Name => Names.Cat();
		string Filter(string input, int i);
		RGBColor ToRGB(IReadOnlyList<string> inputs);
		ImmutableArray<string> FromRGB(RGBColor color);
	}
}
