using SIMSA.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Braille : ContentPage
	{
		public Braille()
		{
			InitializeComponent();
			Title = AppResources.BraillePageTitle;
			BindingContext = new ViewModels.BrailleViewModel();
		}
	}
}