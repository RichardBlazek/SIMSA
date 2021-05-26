using System;
using System.Collections.Immutable;
using SIMSA.Models;

namespace SIMSA.ViewModels
{
	public class MenuVM : ViewModelBase
	{
		public ImmutableArray<ButtonVM> Buttons { get; }
		readonly Action<Config> save;
		public ImmutableArray<ViewModelBase> ViewModels { get; }
		public MenuVM(Config config, Action<Config> save, ImmutableArray<ButtonVM> buttons, ImmutableArray<ViewModelBase> viewModels)
			: base(config)
		{
			Buttons = buttons;
			ViewModels = viewModels;
			this.save = save;
		}
		public override Config Config
		{
			get => base.Config;
			set
			{
				base.Config = value;
				foreach (var vm in ViewModels)
				{
					vm.Config = value;
				}
				save(value);
			}
		}
	}
}
