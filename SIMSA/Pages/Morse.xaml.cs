using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SIMSA.Models;
using System;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Morse : ContentPage
	{
		MorseCode code;
		void SetCode(MorseCode newCode, int position)
		{
			code = newCode;
			output.Text = code.ToLetters();

			input.TextChanged -= TextChangedHandler;
			input.SetText(code.ToString(), position);
			input.TextChanged += TextChangedHandler;
		}
		void TextChangedHandler(object o, EventArgs a) => SetCode(MorseCode.Parse(input.Text), input.CursorPosition);
		public Morse(MorseCode init)
		{
			InitializeComponent();
			code = init;
			add0.Clicked += (o, a) => SetCode(code.Add('0', input.CursorPosition), input.CursorPosition + 1);
			add1.Clicked += (o, a) => SetCode(code.Add('1', input.CursorPosition), input.CursorPosition + 1);
			backspace.Clicked += (o, a) => SetCode(code.Remove(input.CursorPosition - 1), input.CursorPosition - 1);
			separate.Clicked += (o, a) => SetCode(code.Add('|', input.CursorPosition), input.CursorPosition + 1);
			clear.Clicked += (o, a) => SetCode(new MorseCode(), 0);
			invert.Clicked += (o, a) => SetCode(code.Invert(), input.CursorPosition);
			input.TextChanged += TextChangedHandler;
		}
		public Morse() : this(new MorseCode()) { }
	}
}