using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SIMSA.Resources;
using SIMSA.ViewModels;

namespace SIMSA.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Morse : ContentPage
	{
		public Morse(MorseViewModel binaryText)
		{
			InitializeComponent();
			BindingContext = binaryText;
			Title = AppResources.MorsePageTitle;
		}
		public Morse() : this(new MorseViewModel()) { }
	}
}