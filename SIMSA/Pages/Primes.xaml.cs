using System.Collections.Immutable;
using System.Linq;
using SIMSA.Models;
using SIMSA.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Primes : ContentPage, IConfigurable
	{
		public Config Config { get; set; }
		public Primes(Config config)
		{
			Config = config;
			InitializeComponent();
		}

		void FindPrimesUpTo(object sender, TextChangedEventArgs e)
		{
			if (int.TryParse(e.NewTextValue, out int num) && num >= 0)
			{
				var primes = num.GetPrimes();
				primeCount.Text = AppResources.PrimeCount + " " + primes.Length;
				output.Text = primes.Cat(", ");
			}
			else if (e.NewTextValue.Length > 0)
			{
				upperBound.Text = e.NewTextValue.Where(char.IsDigit).Cat();
			}
		}
	}
}