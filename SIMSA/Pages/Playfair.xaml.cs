using SIMSA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Playfair : ContentPage, IConfigurable
	{
		public Config Config { get; set; }

		PlayfairText text;

		void Set(PlayfairText newText)
		{
			text = newText;
			output.Text = text.ToString();
			replaced.Text = newText.Replaced.ToString();
		}

		void SetReplaced(char new_replaced)
		{
			if (new_replaced != text.Replaced)
			{
				Set(text.WithReplaced(new_replaced));
			}
		}
		public Playfair(Config config, PlayfairText initText)
		{
			InitializeComponent();
			Config = config;
			text = initText;

			input.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeCharacter);
			key.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeCharacter);
			replaced.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeCharacter);

			input.TextChanged += (o, a) => Set(text.WithText(a.NewTextValue.ToUpper()));
			key.TextChanged += (o, a) => Set(text.WithKey(a.NewTextValue.ToUpper()));
			replaced.TextChanged += (o, a) => SetReplaced(a.NewTextValue.Length == 1 ? a.NewTextValue.ToUpper()[0] : text.Replaced);

			Set(initText);
		}
	}
}