using System;
using SIMSA.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Morse : ContentPage
	{
		readonly Action<Action<ViewModelBase>> forEachViewModel;
		readonly Action<Action<ContentPage>> forEachPage;
		void ChangeToBinary(ViewModelBase vm)
		{
			if (vm is NumericVM numericVm)
			{
				numericVm.Radix = 2;
				numericVm.Input = (BindingContext as MorseVM)!.AsBinary;
			}
		}
		async void GoToBinary(ContentPage page)
		{
			if (page is Numeric numeric)
			{
				Navigation.InsertPageBefore(numeric, this);
				_ = await Navigation.PopAsync();
			}
		}
		void ToBinary(object sender, EventArgs e)
		{
			forEachViewModel(ChangeToBinary);
			forEachPage(GoToBinary);
		}
		public Morse(Action<Action<ViewModelBase>> forEachViewModel, Action<Action<ContentPage>> forEachPage)
		{
			this.forEachViewModel = forEachViewModel;
			this.forEachPage = forEachPage;
			InitializeComponent();
		}
	}
}