using System;
using System.Collections.Immutable;
using SIMSA.Models;

namespace SIMSA.ViewModels
{
	public class MenuVM : ViewModelBase
	{
		public ImmutableArray<ButtonVM> Buttons { get; }
		readonly Action<Config> save = x => { };
		public ImmutableArray<ViewModelBase> ViewModels { get; } = ImmutableArray<ViewModelBase>.Empty;
		public MenuVM(Config config, Action<Config> save, ImmutableArray<ButtonVM> buttons, ImmutableArray<ViewModelBase> viewModels)
			: base(config)
		{
			Buttons = buttons;
			ViewModels = viewModels;
			this.save = save;
		}
		void Execute(Action<ViewModelBase> modifier)
		{
			foreach (var vm in ViewModels)
			{
				modifier(vm);
			}
		}
		public override Config Config
		{
			get => base.Config;
			set
			{
				base.Config = value;
				Execute(vm => vm.Config = value);
				save(value);
			}
		}
	}
}
