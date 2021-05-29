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
		readonly ImmutableArray<ContentPage> pages;
		void Save(Config config) => (BindingContext as MenuVM)!.Config = config;
		void ForEachViewModel(Action<ViewModelBase> modifier) => (BindingContext as MenuVM)!.ForEach(modifier);
		void ForEachPage(Action<ContentPage> modifier) => pages.ForEach(modifier);
		ICommand CommandFor(ContentPage page) => new Command(async () => await Navigation.PushAsync(page, false));
		public Menu(Config config, Action<Config> save)
		{
			InitializeComponent();
			pages = new ContentPage[]
			{
				new BaseConverter(),
				new Braille(),
				new FlagSemaphore(),
				new FrequencyAnalysis(),
				new Morse(ForEachViewModel, ForEachPage),
				new Numeric(config),
				new Playfair(),
				new Primes(),
				new Vigenere(config),
				new ManageAlphabets(config, Save)
			}.ToImmutableArray();
			var buttons = pages.Select(page => new ButtonVM(page.Title, CommandFor(page))).ToImmutableArray();
			var viewModels = pages.Select(page => page.BindingContext).OfType<ViewModelBase>().ToImmutableArray();
			BindingContext = new MenuVM(config, save, buttons, viewModels);
		}
	}
}