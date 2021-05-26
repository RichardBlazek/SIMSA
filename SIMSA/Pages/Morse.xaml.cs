using SIMSA.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Morse : ContentPage
	{
		public Morse()
		{
			InitializeComponent();
			BindingContext = new MorseVM();
		}
	}
}