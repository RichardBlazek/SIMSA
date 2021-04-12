using System;
using System.Collections.Immutable;
using System.Linq;
using SIMSA.Models;
using SIMSA.Resources;
using Xamarin.Forms;

namespace SIMSA.Pages
{
	public class Menu : ContentPage
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
			this.save = save;
			Title = AppResources.MenuPageTitle;
			
			pages = ImmutableArray.Create<IConfigurable>(new Braille(config, new BrailleText()), new Morse(config, new MorseCode()), new Numeric(config, new NumericCode()), new Settings(config, Save));
			var layout = new StackLayout { Style = Application.Current.Resources["Content"] as Style };
			foreach (var page in pages.OfType<Page>())
			{
				layout.Children.Add(ButtonFor(page));
			}

			Content = new StackLayout { Children = { new ScrollView { Content = layout } } };
		}
	}
}