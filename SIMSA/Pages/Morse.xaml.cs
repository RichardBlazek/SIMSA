using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SIMSA.Models;
using System.Linq;
using System;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Morse : ContentPage
	{
		BinaryCode code;
		void SetCode(BinaryCode newCode, int position)
		{
			code = newCode;
			output.Text = code.ToLettersFromMorse();

			input.TextChanged -= TextChangedHandler;
			input.SetText(code.ToMorse(), position);
			input.TextChanged += TextChangedHandler;
		}
		static string ToBinary(string s) => string.Join("", s.Replace('\u2022', '0').Replace('\u2013', '1').Where(c => c == '0' || c == '1' || c == '|'));
		void TextChangedHandler(object o, EventArgs a) => SetCode(new BinaryCode(ToBinary(input.Text)), input.CursorPosition);
		public Morse(BinaryCode init)
		{
			InitializeComponent();
			code = init;
			add0.Clicked += (o, a) => SetCode(code.Add('0', input.CursorPosition), input.CursorPosition + 1);
			add1.Clicked += (o, a) => SetCode(code.Add('1', input.CursorPosition), input.CursorPosition + 1);
			delete.Clicked += (o, a) => SetCode(code.Remove(input.CursorPosition - 1), input.CursorPosition - 1);
			separate.Clicked += (o, a) => SetCode(code.Add('|', input.CursorPosition), input.CursorPosition + 1);
			clear.Clicked += (o, a) => SetCode(new BinaryCode(), 0);
			invert.Clicked += (o, a) => SetCode(code.Invert(), input.CursorPosition);
			input.TextChanged += TextChangedHandler;
		}
		public Morse() : this(new BinaryCode()) { }
	}
}