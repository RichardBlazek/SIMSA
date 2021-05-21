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
		BrailleText braille;

		void SetText(BrailleText bt)
		{
			braille = bt;
			output.Text = braille.ToString();
			for (int i = 0; i < 6; ++i)
			{
				buttons[i].BackgroundColor = braille[^1, i] ? new Color(1, 1, 1) : new Color(0, 0, 0);
			}
		}

		Button MakeBraile(int value) => new Button { Command = new Command(() => SetText(braille.InvertAt(value))) };
		public Braille(Config config, BrailleText brailleText)
		{
			InitializeComponent();
			Config = config;
			braille = brailleText;

			buttons = 6.Range(MakeBraile).ToImmutableArray();
			for (int i = 0; i < 6; ++i)
			{
				grid.Children.Add(buttons[i], i % 2, i / 2);
			}

			backspace.Clicked += (o, a) => SetText(braille.Pop());
			clear.Clicked += (o, a) => SetText(new BrailleText());
			confirm.Clicked += (o, a) => SetText(braille.Add(0));
			invert.Clicked += (o, a) => SetText(braille.Inverted);
			mirror.Clicked += (o, a) => SetText(braille.Mirrored);
			turn.Clicked += (o, a) => SetText(braille.Turned);

			SetText(braille);
		}
	}
}