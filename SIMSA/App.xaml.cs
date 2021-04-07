using SIMSA.Models;
using Xamarin.Forms;

namespace SIMSA
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new Views.Menu(LoadAlphabets(), SaveAlphabets));
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
		async void SaveAlphabets(Alphabets alphabets)
		{
			Properties["Alphabets"] = alphabets;
			await SavePropertiesAsync();
		}

		protected override void OnStart() { }
		protected override void OnSleep() { }
		protected override void OnResume() { }
	}
}
