using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Windows.Input;
using SIMSA.Models;
using Xamarin.Forms;

namespace SIMSA.ViewModels
{
	public class BrailleViewModel : ViewModelBase
	{
		BrailleText braille = new BrailleText();
		public BrailleText Braille
		{
			get => braille;
			protected set
			{
				braille = value;
				OnPropertyChanged("Text");
				for (int i = 0; i < 6; ++i)
				{
					OnPropertyChanged("ColorAt" + i);
				}
			}
		}
		public string Text => Braille.ToString();
		public Color ColorAt0 => braille[^1, 0] ? new Color(1, 1, 1) : new Color(0, 0, 0);
		public Color ColorAt1 => braille[^1, 1] ? new Color(1, 1, 1) : new Color(0, 0, 0);
		public Color ColorAt2 => braille[^1, 2] ? new Color(1, 1, 1) : new Color(0, 0, 0);
		public Color ColorAt3 => braille[^1, 3] ? new Color(1, 1, 1) : new Color(0, 0, 0);
		public Color ColorAt4 => braille[^1, 4] ? new Color(1, 1, 1) : new Color(0, 0, 0);
		public Color ColorAt5 => braille[^1, 5] ? new Color(1, 1, 1) : new Color(0, 0, 0);
		public ICommand Clicked { get; protected set; }
		public ICommand Confirm { get; protected set; }
		public ICommand Delete { get; protected set; }
		public ICommand Clear { get; protected set; }
		public ICommand Invert { get; protected set; }
		public BrailleViewModel()
		{
			Clicked = new Command<string>(bit => Braille = braille.InvertAt(int.Parse(bit)));
			Confirm = new Command(() => Braille = braille.Add(0));
			Delete = new Command(() => Braille = braille.Pop());
			Clear = new Command(() => Braille = new BrailleText());
			Invert = new Command(() => Braille = braille.Invert());
		}
	}
}
