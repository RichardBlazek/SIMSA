using System;
using System.Windows.Input;
using SIMSA.Models;
using Xamarin.Forms;

namespace SIMSA.ViewModels
{
	public class NumericVM : ViewModelBase
	{
		NumericText text;
		public string Output => text.ToString();
		public string Input
		{
			get => text.Text;
			set => ChangeProperty(ref text, text.WithText(value), "Input", "Output");
		}
		public byte Radix
		{
			get => text.Radix;
			set => ChangeProperty(ref text, text.WithRadix(value), "Input", "Output", "Radix");
		}
		public ICommand Invert { get; }
		public ICommand SelectAlphabet { get; }
		void SetAlphabet(IAlphabet alphabet) => ChangeProperty(ref text, text.WithAlphabet(alphabet), "Output");
		public NumericVM(Config config, Action<Action<IAlphabet>> selectAlphabet) : base(config)
		{
			text = new NumericText(config.DefaultAlphabet);
			Invert = new Command(() => ChangeProperty(ref text, text.Invert(), "Input", "Output"));
			SelectAlphabet = new Command(() => selectAlphabet(SetAlphabet));
		}
	}
}
