using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SIMSA.ViewModels;

namespace SIMSA.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Braille : ContentPage
	{
		public Braille()
		{
			InitializeComponent();
			BindingContext = new BrailleViewModel();
		}
	}
}