using System;
using System.Threading.Tasks;
using SIMSA.Models;
using SIMSA.Resources;
using Xamarin.Forms;

namespace SIMSA.Views
{
	public class Settings : ContentPage
	{
		Alphabets alphabets;
		readonly Action<Alphabets> saveAlphabets;
		readonly StackLayout stack;
		Task OpenEditAsync(int customIndex) => Navigation.PushAsync(new EditAlphabet(alphabets, SaveAlphabets, customIndex), false);
		Task NewAlphabetAsync()
		{
			SaveAlphabets(alphabets.Add(CustomAlphabet.Empty));
			return OpenEditAsync(alphabets.Custom.Count - 1);
		}
		Button EditOpener(int customIndex) => new Button
		{
			Text = alphabets.Custom[customIndex].Name,
			Command = new Command(async () => await OpenEditAsync(customIndex)),
			Style = Application.Current.Resources["MenuButton"] as Style
		};
		void ReloadContent()
		{
			stack.Children.Clear();
			stack.Children.Add(new Label { Text = AppResources.Alphabets, Style = Application.Current.Resources["HeaderLabel"] as Style });
			for (int i = 0, count = alphabets.Custom.Count; i < count; ++i)
			{
				stack.Children.Add(EditOpener(i));
			}
			stack.Children.Add(new Button
			{
				Text = AppResources.AddAlphabet,
				Command = new Command(async () => await NewAlphabetAsync()),
				Style = Application.Current.Resources["MenuButton"] as Style
			});
		}
		void SaveAlphabets(Alphabets alphabets)
		{
			this.alphabets = alphabets;
			saveAlphabets(alphabets);
			ReloadContent();
		}
		public Settings(Alphabets alphabets, Action<Alphabets> saveAlphabets)
		{
			this.saveAlphabets = saveAlphabets;
			Content = stack = new StackLayout();
			SaveAlphabets(alphabets);
			Title = AppResources.SettingsPageTitle;
			Style = Application.Current.Resources["Page"] as Style;
		}
	}
}