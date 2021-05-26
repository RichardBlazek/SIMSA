using System.ComponentModel;
using SIMSA.Models;

namespace SIMSA.ViewModels
{
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public virtual Config Config { get; set; }
		protected ViewModelBase(Config config) => Config = config;
		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		protected void ChangeProperty<T>(ref T changed, T value, params string[] names)
		{
			if (!Equals(value, changed))
			{
				changed = value;
				for (int i = 0; i < names.Length; ++i)
				{
					OnPropertyChanged(names[i]);
				}
			}
		}
	}
}
