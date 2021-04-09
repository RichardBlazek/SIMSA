using System;
using SIMSA.Models;
using SIMSA.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Numeric : ContentPage
	{
		readonly Button[] keyboard = new Button[36];
		NumericCode code;
		IAlphabet alphabet;
		void Set(NumericCode cd, int position)
		{
			int invertFrom = Math.Min(cd.Radix, code.Radix), invertTo = Math.Max(cd.Radix, code.Radix);
			code = cd;
			radixLabel.Text = code.Radix.ToString();
			output.Text = cd.ToLetters(alphabet);

			input.TextChanged -= TextChangedHandler;
			input.SetText(cd.ToString(), position);
			input.TextChanged += TextChangedHandler;

			for (int i = invertFrom; i < invertTo; ++i)
			{
				keyboard[i].IsVisible = !keyboard[i].IsVisible;
			}
		}
		void TextChangedHandler(object o, TextChangedEventArgs a) => Set(NumericCode.Parse(input.Text, code.Radix), input.CursorPosition);
		Button MakeKey(int i) => new Button
		{
			Text = NumericCode.Digits[i].ToString(),
			Style = Application.Current.Resources["InputButton"] as Style,
			Command = new Command(() => Set(code.Add(NumericCode.Digits[i], input.CursorPosition), input.CursorPosition + 1))
		};
		public Numeric(NumericCode initCode, IAlphabet alphabet)
		{
			code = initCode;
			this.alphabet = alphabet;
			InitializeComponent();

			radixInc.Clicked += (o, a) => Set(code.WithRadix((byte)(code.Radix + 1)), input.CursorPosition);
			radixDec.Clicked += (o, a) => Set(code.WithRadix((byte)(code.Radix - 1)), input.CursorPosition);
			clear.Clicked += (o, a) => Set(new NumericCode(), 0);
			backspace.Clicked += (o, a) => Set(code.Remove(input.CursorPosition - 1), input.CursorPosition - 1);
			invert.Clicked += (o, a) => Set(code.Invert(), input.CursorPosition);
			separate.Clicked += (o, a) => Set(code.Add('|', input.CursorPosition), input.CursorPosition + 1);

			input.TextChanged += TextChangedHandler;
			for (int i = 0; i < keyboard.Length; ++i)
			{
				keyboard[i] = MakeKey(i);
				keyboard[i].IsVisible = i < code.Radix;
				grid.Children.Add(keyboard[i], i % 6, i / 6 + 4);
			}

			Set(code, code.Length);
		}
		public Numeric(IAlphabet alphabet) : this(new NumericCode(), alphabet) { }
	}
}