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
		void SetText(VigenereText newText)
		{
			text = newText;
			sign.Text = text.Minus ? "\u2212" : "+";
			output.Text = text.DecipheredIn(alphabet);
		}
		void SetAlphabet(IAlphabet newAlphabet)
		{
			alphabet = newAlphabet;
			alphabetBtn.Text = newAlphabet.Name;
			output.Text = text.DecipheredIn(alphabet);
		}
		public Vigenere(Config config, VigenereText initText)
		{
			InitializeComponent();
			Config = config;
			text = initText;
			alphabet = config.DefaultAlphabet;

			input.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeCharacter);
			key.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeCharacter);

			alphabetBtn.Clicked += async (o, a) => await Navigation.PushAsync(new SelectAlphabet(Config.Alphabets, SetAlphabet), false);
			input.TextChanged += (o, a) => SetText(text.WithText(a.NewTextValue.ToUpper()));
			key.TextChanged += (o, a) => SetText(text.WithKey(a.NewTextValue.ToUpper()));
			sign.Clicked += (o, a) => SetText(text.InvertSign());

			SetAlphabet(alphabet);
		}
	}
}