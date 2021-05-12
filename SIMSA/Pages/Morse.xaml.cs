using System;
using SIMSA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Morse : ContentPage, IConfigurable
	{
		public Config Config { get; set; }

		Models.Morse morse;

		void SetCode(Models.Morse newMorse, int position)
		{
			morse = newMorse;
			output.Text = morse.ToString();

			input.TextChanged -= TextChangedHandler;
			input.SetText(morse.Text, position);
			input.TextChanged += TextChangedHandler;
		}

		void TextChangedHandler(object o, EventArgs a) => SetCode(Models.Morse.Parse(input.Text), input.CursorPosition);
		public Morse(Config config, Models.Morse morseCode)
		{
			InitializeComponent();
			Config = config;
			morse = morseCode;

			add0.Clicked += (o, a) => SetCode(morse.Add('\u2022', input.CursorPosition), input.CursorPosition + 1);
			add1.Clicked += (o, a) => SetCode(morse.Add('\u2013', input.CursorPosition), input.CursorPosition + 1);
			backspace.Clicked += (o, a) => SetCode(morse.Remove(input.CursorPosition - 1), input.CursorPosition - 1);
			separate.Clicked += (o, a) => SetCode(morse.Add('/', input.CursorPosition), input.CursorPosition + 1);
			clear.Clicked += (o, a) => SetCode(new Models.Morse(), 0);
			invert.Clicked += (o, a) => SetCode(morse.Invert(), input.CursorPosition);
			input.TextChanged += TextChangedHandler;
		}
	}
}