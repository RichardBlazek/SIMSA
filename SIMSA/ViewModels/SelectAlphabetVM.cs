using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using SIMSA.Models;
using Xamarin.Forms;

namespace SIMSA.ViewModels
{
	public class SelectAlphabetVM : ViewModelBase
	{
		readonly Action<IAlphabet> select;
		ICommand CommandFor(IAlphabet alphabet) => new Command(() => select(alphabet));
		public IEnumerable<ButtonVM> Buttons => Config.Alphabets.Select(abc => new ButtonVM(abc.Name, CommandFor(abc)));
		public SelectAlphabetVM(Config config, Action<IAlphabet> select) : base(config) => this.select = select;
	}
}
