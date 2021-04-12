using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using SIMSA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Numeric : ContentPage, IConfigurable
	{
		public Config Config { get; set; }
		readonly ImmutableArray<Button> keyboard;
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
			Command = new Command(() => Set(code.Add(NumericCode.Digits[i], input.CursorPosition), input.CursorPosition + 1))
		};
		void SetAlphabet(IAlphabet alphabet)
		{
			this.alphabet = alphabet;
			selectAlphabet.Text = alphabet.Name;
			Set(code, code.Length);
		}
		Task OpenSelectAlphabet() => Navigation.PushAsync(new SelectAlphabet(Config.Alphabets, SetAlphabet), false);
		public Numeric(Config config, NumericCode initCode)
		{
			InitializeComponent();

			Config = config;
			code = initCode;

			selectAlphabet.Clicked += async (o, a) => await OpenSelectAlphabet();
			input.TextChanged += TextChangedHandler;

			radixInc.Clicked += (o, a) => Set(code.WithRadix((byte)(code.Radix + 1)), input.CursorPosition);
			radixDec.Clicked += (o, a) => Set(code.WithRadix((byte)(code.Radix - 1)), input.CursorPosition);
			clear.Clicked += (o, a) => Set(new NumericCode(), 0);
			backspace.Clicked += (o, a) => Set(code.Remove(input.CursorPosition - 1), input.CursorPosition - 1);
			invert.Clicked += (o, a) => Set(code.Invert(), input.CursorPosition);
			separate.Clicked += (o, a) => Set(code.Add('|', input.CursorPosition), input.CursorPosition + 1);

			keyboard = 36.Range(MakeKey).ToImmutableArray();
			for (int i = 0; i < keyboard.Length; ++i)
			{
				keyboard[i].IsVisible = i < code.Radix;
				grid.Children.Add(keyboard[i], (i + 3) % 6, (i + 3) / 6 + 4);
			}

			SetAlphabet(config.DefaultAlphabet);
		}
	}
}