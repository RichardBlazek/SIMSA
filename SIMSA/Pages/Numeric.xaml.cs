using SIMSA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Numeric : ContentPage, IConfigurable
	{
		public Config Config { get; set; }

		Models.Numeric code;
		IAlphabet alphabet;

		void SetCode(Models.Numeric newCode, bool changeEntry, bool changeRadix = true)
		{
			code = newCode;
			if (changeRadix)
			{
				radix.Text = code.Radix.ToString();
			}
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
		void SetRadix(byte radix)
		{
			if (radix >= 2 && radix <= 36 && radix != code.Radix)
			{
				SetCode(code.WithRadix(radix), true, false);
			}
		}
		public Numeric(Config config, Models.Numeric initCode)
		{
			InitializeComponent();
			Config = config;
			code = initCode;
			alphabet = config.DefaultAlphabet;

			alphabetBtn.Clicked += async (o, a) => await Navigation.PushAsync(new SelectAlphabet(Config.Alphabets, SetAlphabet), false);
			input.TextChanged += (o, a) => SetCode(Models.Numeric.Parse(input.Text, code.Radix), !code.IsTextValid(input.Text));
			radix.TextChanged += (o, a) => SetRadix(byte.TryParse(radix.Text, out byte r) ? r : code.Radix);
			invert.Clicked += (o, a) => SetCode(code.Invert(), true);

			input.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeCharacter);
			SetAlphabet(alphabet);
		}
	}
}