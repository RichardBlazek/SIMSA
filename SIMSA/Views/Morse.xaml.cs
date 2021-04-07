using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
		}
		public Morse() : this(new MorseViewModel()) { }
	}
}