using Xamarin.Forms;
using System.Windows.Input;
using SIMSA.Models;

namespace SIMSA.ViewModels
{
	public class MorseViewModel : ViewModelBase
    {
        BinaryCode text = new BinaryCode();
        public BinaryCode Text
        {
            get => text;
            protected set
            {
                text = value;
                OnPropertyChanged("Text");
                OnPropertyChanged("MorseFormat");
                OnPropertyChanged("MorseConvert");
            }
        }
        public ICommand Add { get; protected set; }
        public ICommand Delete { get; protected set; }
        public ICommand Clear { get; protected set; }
        public ICommand Invert { get; protected set; }

        public MorseViewModel()
		{
            Add = new Command<string>(added => Text = text.Add(added[0]), added => added.Length == 1);
            Invert = new Command(() => Text = text.Invert());
            Delete = new Command(() => Text = text.PopBit());
            Clear = new Command(() => Text = new BinaryCode());
		}

        public string Morse => text.ToMorse();
        public string Alphabetic => text.ToLettersFromMorse();
	}
}
