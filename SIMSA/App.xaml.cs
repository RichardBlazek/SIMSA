using Xamarin.Forms;
using System.Text.Json;

namespace SIMSA
{
	public partial class App : Application
	{
		T GetProperty<T>(string key) => JsonSerializer.Deserialize<T>((Properties[key] as string)!)!;
		void SetProperty<T>(string key, T value) => Properties[key] = JsonSerializer.Serialize(value);

		public App()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new Views.Menu());
		}

		protected override void OnStart() { }
		protected override async void OnSleep() => await SavePropertiesAsync();
		protected override void OnResume() { }
	}
}
