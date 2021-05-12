using System.Collections.Immutable;
using SIMSA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Braille : ContentPage, IConfigurable
	{
		public Config Config { get; set; }

		readonly ImmutableArray<Button> buttons;
		Models.Braille braille;

		void SetText(Models.Braille bt)
		{
			braille = bt;
			output.Text = braille.ToString();
			for (int i = 0; i < 6; ++i)
			{
				buttons[i].BackgroundColor = braille[^1, i] ? new Color(0, 0, 0) : new Color(1, 1, 1);
			}
		}

		Button MakeBraile(int value) => new Button
		{
			Style = Resources["CircleButton"] as Style,
			Command = new Command(() => SetText(braille.InvertAt(value)))
		};
		public Braille(Config config, Models.Braille brailleText)
		{
			InitializeComponent();
			Config = config;
			braille = brailleText;

			buttons = 6.Range(MakeBraile).ToImmutableArray();
			for (int i = 0; i < 6; ++i)
			{
				grid.Children.Add(buttons[i], 2 + i % 2, 1 + i / 2);
			}

			backspace.Clicked += (o, a) => SetText(braille.Pop());
			clear.Clicked += (o, a) => SetText(new Models.Braille());
			confirm.Clicked += (o, a) => SetText(braille.Add(0));
			invert.Clicked += (o, a) => SetText(braille.Invert());

			SetText(braille);
		}
	}
}