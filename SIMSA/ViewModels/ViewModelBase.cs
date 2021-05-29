﻿using System.ComponentModel;
using SIMSA.Models;

namespace SIMSA.ViewModels
{
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public virtual Config Config { get; set; }
		protected ViewModelBase(Config config) => Config = config;
		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		protected void ChangeProperty<T>(ref T variable, T newValue, params string[] effects)
		{
			if (!Equals(newValue, variable))
			{
				variable = newValue;
				for (int i = 0; i < effects.Length; ++i)
				{
					OnPropertyChanged(effects[i]);
				}
			}
		}
		protected void ChangePropertyUI<T, U>(ref T variable, T newValue, U oldDisplayed, U newDisplayed, params string[] effects)
		{
			if (!Equals(oldDisplayed, newDisplayed) || !Equals(newValue, variable))
			{
				variable = newValue;
				for (int i = 0; i < effects.Length; ++i)
				{
					OnPropertyChanged(effects[i]);
				}
			}
		}
	}
}
