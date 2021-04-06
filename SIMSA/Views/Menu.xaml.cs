using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SIMSA.Resources;

namespace SIMSA.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : ContentPage
	{
		Button ButtonFor(Page page) => new Button
		{
			Text = page.Title,
			Command = new Command(async () => await Navigation.PushAsync(page, false)),
			Style = Application.Current.Resources["MenuButton"] as Style
		};
		public Menu()
		{
			InitializeComponent();
			Title = AppResources.MenuPageTitle;
			options.Children.Add(ButtonFor(new Morse()));
			options.Children.Add(ButtonFor(new Braille()));
		}
	}
}