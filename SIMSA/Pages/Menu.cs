using System;
using SIMSA.Models;
using SIMSA.Resources;
using Xamarin.Forms;

namespace SIMSA.Pages
{
	public class Menu : ContentPage
	{
		Button ButtonFor(Page page) => new Button
		{
			Text = page.Title,
			Command = new Command(async () => await Navigation.PushAsync(page, false)),
			Style = Application.Current.Resources["MenuButton"] as Style
		};
		public Menu(Alphabets alphabets, Action<Alphabets> saveAlphabets)
		{
			Title = AppResources.MenuPageTitle;
			Style = Application.Current.Resources["Page"] as Style;
			Content = new StackLayout
			{
				Children = {
					new ScrollView
					{
						Content = new StackLayout
						{
							Children = {
								ButtonFor(new Braille()),
								ButtonFor(new Morse()),
								ButtonFor(new Numeric(new UnicodeAlphabet())),
								ButtonFor(new Settings(alphabets, saveAlphabets))
							}
						}
					}
				}
			};
		}
	}
}