using System;
using System.Collections.Immutable;
using System.Linq;
using System.Windows.Input;
using SIMSA.Models;
using SIMSA.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : ContentPage
	{
		void Execute(Action<ViewModelBase> modifier)
		{
			foreach (var vm in (BindingContext as MenuVM)!.ViewModels)
			{
				modifier(vm);
			}
		}
		void Save(Config config) => (BindingContext as MenuVM)!.Config = config;
		ICommand CommandFor(ContentPage page) => new Command(async () => await Navigation.PushAsync(page, false));
		MenuVM MakeViewModel(Config config, Action<Config> save)
		{
			var contentPages = new ContentPage[]
			{
				new Braille(),
				new Morse(),
				new Numeric(config),
				new Vigenere(config),
				new FlagSemaphore(),
				new Playfair(),
				new Primes(),
				new BaseConverter(),
				new FrequencyAnalysis(),
				new ManageAlphabets(config, Save)
			};

			var buttons = contentPages.Select(page => new ButtonVM(page.Title, CommandFor(page))).ToImmutableArray();
			var viewModels = contentPages.Select(page => (page.BindingContext as ViewModelBase)!).ToImmutableArray();
			return new MenuVM(config, save, buttons, viewModels);
		}
		public Menu(Config config, Action<Config> save)
		{
			InitializeComponent();
			BindingContext = MakeViewModel(config, save);
		}
	}
}