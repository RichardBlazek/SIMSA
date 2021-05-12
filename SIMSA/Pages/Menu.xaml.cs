using System;
using System.Collections.Immutable;
using SIMSA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : ContentPage
	{
		readonly Action<Config> save;
		readonly ImmutableArray<IConfigurable> pages;

		void Save(Config config)
		{
			foreach (var page in pages)
			{
				page.Config = config;
			}
			save(config);
		}

		Button ButtonFor<T>(T page) where T : Page => new Button
		{
			Text = page.Title,
			Command = new Command(async () => await Navigation.PushAsync(page, false))
		};
		public Menu(Config config, Action<Config> save)
		{
			InitializeComponent();

			this.save = save;
			pages = ImmutableArray.Create<IConfigurable>(new Braille(config, new Models.Braille()), new Morse(config, new Models.Morse()), new Numeric(config, new Models.Numeric()), new Vigenere(config, new Models.Vigenere()), new FlagSemaphore(config, new Models.FlagSemaphore()), new Playfair(config, new Models.Playfair()), new Primes(config), new BaseConverter(config), new Settings(config, Save));
			foreach (var page in pages.OfType<Page>())
			{
				stack.Children.Add(ButtonFor(page));
			}
		}
	}
}