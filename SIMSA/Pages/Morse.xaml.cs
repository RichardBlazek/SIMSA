using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SIMSA.Models;
using System;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Morse : ContentPage, IConfigurable
	{
		public Config Config { get; set; }
		MorseCode morse;
		void SetCode(MorseCode newMorse, int position)
		{
			morse = newMorse;
			output.Text = morse.ToLetters();

			input.TextChanged -= TextChangedHandler;
			input.SetText(morse.ToString(), position);
			input.TextChanged += TextChangedHandler;
		}
		void TextChangedHandler(object o, EventArgs a) => SetCode(MorseCode.Parse(input.Text), input.CursorPosition);
		public Morse(Config config, MorseCode morseCode)
		{
			InitializeComponent();
			Config = config;
			morse = morseCode;

			add0.Clicked += (o, a) => SetCode(morse.Add('\u2022', input.CursorPosition), input.CursorPosition + 1);
			add1.Clicked += (o, a) => SetCode(morse.Add('\u2013', input.CursorPosition), input.CursorPosition + 1);
			backspace.Clicked += (o, a) => SetCode(morse.Remove(input.CursorPosition - 1), input.CursorPosition - 1);
			separate.Clicked += (o, a) => SetCode(morse.Add('/', input.CursorPosition), input.CursorPosition + 1);
			clear.Clicked += (o, a) => SetCode(new MorseCode(), 0);
			invert.Clicked += (o, a) => SetCode(morse.Invert(), input.CursorPosition);
			input.TextChanged += TextChangedHandler;
		}
	}
}