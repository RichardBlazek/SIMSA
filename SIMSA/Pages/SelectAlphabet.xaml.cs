using System;
using System.Threading.Tasks;
using SIMSA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectAlphabet : ContentPage
	{
		Task Selected(IAlphabet alphabet, Action<IAlphabet> onSelected)
		{
			onSelected(alphabet);
			return Navigation.PopAsync(false);
		}
		Button AlphabetSelector(IAlphabet alphabet, Action<IAlphabet> onSelected) => new Button
		{
			Text = alphabet.Name,
			Style = Application.Current.Resources["Button"] as Style,
			Command = new Command(async () => await Selected(alphabet, onSelected))
		};
		public SelectAlphabet(Alphabets alphabets, Action<IAlphabet> onSelected)
		{
			InitializeComponent();
			foreach (var alphabet in alphabets)
			{
				buttons.Children.Add(AlphabetSelector(alphabet, onSelected));
			}
		}
	}
}