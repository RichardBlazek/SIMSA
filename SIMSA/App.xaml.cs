using SIMSA.Models;
using Xamarin.Forms;

namespace SIMSA
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new Views.Menu(LoadAlphabets(), ab => Properties["Alphabets"] = ab));
		}

		Alphabets LoadAlphabets()
		{
			if (Properties.ContainsKey("Alphabets"))
			{
				return Alphabets.Parse((string)Properties["Alphabets"]);
			}
			Properties["Alphabets"] = Alphabets.Initial.ToString();
			return Alphabets.Initial;
		}

		protected override void OnStart() { }
		protected override async void OnSleep() => await SavePropertiesAsync();
		protected override void OnResume() { }
	}
}
