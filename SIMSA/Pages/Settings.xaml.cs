using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMSA.Models;
using SIMSA.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Settings : ContentPage, IConfigurable
	{
		public Config Config { get; set; }
		readonly Action<Config> save;

		Task OpenEditAsync(int i)
		{
			var page = new EditAlphabet(Config.Alphabets, alphabets => Save(Config.With(alphabets)), i);
			return Navigation.PushAsync(page, false);
		}
		Task NewAlphabetAsync()
		{
			Save(Config.Add(CustomAlphabet.Empty));
			return OpenEditAsync(Config.Alphabets.Custom.Count - 1);
		}
		Button EditOpener(int i) => new Button
		{
			Text = Config.Alphabets.Custom[i].Name,
			Command = new Command(async () => await OpenEditAsync(i))
		};
		void ReloadContent()
		{
			stack.Children.Clear();
			stack.Children.Add(new Label { Text = AppResources.Alphabets, Style = Application.Current.Resources["Caption"] as Style });

			Config.Alphabets.Custom.Count.Range(i => stack.Children.Add(EditOpener(i)));
			stack.Children.Add(new Button
			{
				Text = AppResources.AddAlphabet,
				Command = new Command(async () => await NewAlphabetAsync())
			});
		}
		void Save(Config config)
		{
			Config = config;
			save(Config);
			ReloadContent();
		}
		public Settings(Config config, Action<Config> save)
		{
			InitializeComponent();
			this.save = save;
			Config = config;
			ReloadContent();
		}
	}
}