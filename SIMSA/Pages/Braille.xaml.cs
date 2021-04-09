using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SIMSA.Models;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Braille : ContentPage
	{
		readonly Button[] buttons = new Button[6];
		BrailleText braille;
		void SetBrailleText(BrailleText bt)
		{
			braille = bt;
			output.Text = braille.ToString();
			for (int i = 0; i < 6; ++i)
			{
				buttons[i].BackgroundColor = braille[^1, i] ? new Color(1, 1, 1) : new Color(0, 0, 0);
			}
		}
		Button MakeBraile(int value) => new Button
		{
			Style = Resources["CircleButton"] as Style,
			Command = new Command(() => SetBrailleText(braille.InvertAt(value)))
		};
		public Braille(BrailleText bt)
		{
			InitializeComponent();
			braille = bt;

			for (int i = 0; i < 6; ++i)
			{
				buttons[i] = MakeBraile(i);
				grid.Children.Add(buttons[i], 2 + i % 2, 1 + i / 2);
			}
			backspace.Clicked += (o, a) => SetBrailleText(braille.Pop());
			clear.Clicked += (o, a) => SetBrailleText(new BrailleText());
			confirm.Clicked += (o, a) => SetBrailleText(braille.Add(0));
			invert.Clicked += (o, a) => SetBrailleText(braille.Invert());

			SetBrailleText(bt);
		}
		public Braille() : this(new BrailleText()) { }
	}
}