using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SIMSA.Models;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Vigenere : ContentPage, IConfigurable
	{
		public Config Config { get; set; }
		VigenereText text;
		IAlphabet alphabet;
		void SetText(VigenereText newText, bool changeEntries)
		{
			text = newText;
			output.Text = text.DecipheredIn(alphabet);
			if (changeEntries)
			{
				input.Text = text.Text;
				key.Text = text.Key;
			}
		}
		void SetAlphabet(IAlphabet newAlphabet)
		{
			alphabet = newAlphabet;
			alphabetBtn.Text = newAlphabet.Name;
			SetText(text, false);
		}
		public Vigenere(Config config, VigenereText initText)
		{
			InitializeComponent();
			Config = config;
			text = initText;

			input.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeCharacter);
			key.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeCharacter);

			alphabetBtn.Clicked += async (o, a) => await Navigation.PushAsync(new SelectAlphabet(Config.Alphabets, SetAlphabet), false);
			input.TextChanged += (o, a) => SetText(new VigenereText(a.NewTextValue.ToUpper(), text.Key), false);
			key.TextChanged += (o, a) => SetText(new VigenereText(text.Text, a.NewTextValue.ToUpper()), false);
			invert.Clicked += (o, a) => SetText(text.InvertKey(alphabet), true);

			SetAlphabet(config.DefaultAlphabet);
		}
	}
}