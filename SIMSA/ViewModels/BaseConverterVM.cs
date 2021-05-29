using System.Linq;
using SIMSA.Models;

namespace SIMSA.ViewModels
{
	public class BaseConverterVM : ViewModelBase
	{
		public BaseConverterVM() : base(Config.Initial) { }
		int fromRadix, toRadix;
		string input = "";
		static string Filter(string s, long radix) => s.ToUpper().Where((c, i) => (i == 0 && c == '-') || (c >= '0' && c < '0' + radix) || (c >= 'A' && c < 'A' + radix - 10 && c <= 'Z')).Cat();
		public int FromRadix
		{
			get => fromRadix;
			set
			{
				ChangeProperty(ref fromRadix, value, "FromRadix");
				ChangeProperty(ref input, Filter(input, fromRadix), "Input", "Output");
			}
		}
		public int ToRadix
		{
			get => toRadix;
			set => ChangeProperty(ref toRadix, value, "ToRadix", "Output");
		}
		public string Input
		{
			get => input;
			set => ChangePropertyUI(ref input, Filter(value, fromRadix), input, value, "Input", "Output");
		}
		public string Output => input.TryParse(fromRadix, out long value) ? value.ToString(toRadix) : "";
	}
}
