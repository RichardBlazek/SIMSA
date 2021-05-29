﻿using System.Windows.Input;
using SIMSA.Models;
using Xamarin.Forms;

namespace SIMSA.ViewModels
{
	public class MorseVM : ViewModelBase
	{
		MorseText text = new MorseText();
		public string Output => text.ToString();
		public string Input
		{
			get => text.Text;
			set => ChangePropertyUI(ref text, MorseText.Parse(value), text.Text, value, "Input", "Output");
		}
		public ICommand Invert { get; }
		public ICommand ToBinary { get; }
		public MorseVM() : base(Config.Initial)
		{
			Invert = new Command(() => ChangeProperty(ref text, text.Inverted, "Input", "Output"));
			ToBinary = new Command(() => { });
		}
	}
}
