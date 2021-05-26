using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using SIMSA.Models;
using SIMSA.Resources;
using Xamarin.Forms;

namespace SIMSA.ViewModels
{
	public class ManageAlphabetsVM : ViewModelBase
	{
		readonly Action<Config, Action<Config>, int> select;
		readonly Action<Config> save;
		ICommand CommandFor(int i) => new Command(() => select(Config, save, i));
		ICommand AddAlphabetCommand => new Command(() =>
		{
			Config = Config.Add(CustomAlphabet.Empty);
			select(Config, save, Config.Alphabets.Custom.Count - 1);
		});
		ButtonVM AddAlphabetButton => new ButtonVM(AppResources.AddAlphabet, AddAlphabetCommand);
		public IEnumerable<ButtonVM> Buttons => Config.Alphabets.Custom.Select((abc, i) => new ButtonVM(abc.Name, CommandFor(i))).Append(AddAlphabetButton);
		public ManageAlphabetsVM(Config config, Action<Config> save, Action<Config, Action<Config>, int> select) : base(config)
		{
			this.select = select;
			this.save = save;
		}
	}
}
