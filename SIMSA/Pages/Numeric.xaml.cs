using SIMSA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Numeric : ContentPage, IConfigurable
	{
		public Config Config { get; set; }
		NumericCode code;
		IAlphabet alphabet;
		void SetCode(NumericCode newCode, bool changeEntry)
		{
			code = newCode;
			radix.Text = code.Radix.ToString();
			output.Text = code.ToLetters(alphabet);
			if (changeEntry)
			{
				input.Text = code.ToString();
			}
		}
		void SetAlphabet(IAlphabet newAlphabet)
		{
			alphabet = newAlphabet;
			alphabetBtn.Text = newAlphabet.Name;
			SetCode(code, false);
		}
		public Numeric(Config config, NumericCode initCode)
		{
			InitializeComponent();
			Config = config;
			code = initCode;
			alphabet = config.DefaultAlphabet;

			alphabetBtn.Clicked += async (o, a) => await Navigation.PushAsync(new SelectAlphabet(Config.Alphabets, SetAlphabet), false);
			input.TextChanged += (o, a) => SetCode(NumericCode.Parse(input.Text, code.Radix), !code.IsTextValid(input.Text));
			radix.Unfocused += (o, a) => SetCode(code.WithRadix(byte.TryParse(radix.Text, out byte r) ? r : code.Radix), true);
			invert.Clicked += (o, a) => SetCode(code.Invert(), true);

			SetAlphabet(alphabet);
		}
	}
}