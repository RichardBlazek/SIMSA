using SIMSA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BaseConverter : ContentPage, IConfigurable
	{
		public Config Config { get; set; }
		public BaseConverter(Config config)
		{
			InitializeComponent();
			Config = config;
			input.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeCharacter);

			fromRadix.Text = "10";
			toRadix.Text = "2";
			input.Text = "0";
		}
		void WriteOutput()
		{
			fromRadix.Clamp(2, long.MaxValue);
			toRadix.Clamp(2, long.MaxValue);
			input.Clamp(long.MinValue, long.MaxValue, 36);

			if (fromRadix.Text.TryParse(10, out long from) && from >= 2)
			{
				input.Clamp(long.MinValue, long.MaxValue, from);
				if (toRadix.Text.TryParse(10, out long to) && to >= 2 && input.Text.TryParse(from, out long value))
				{
					output.Text = value.ToString(to);
				}
			}
		}
		void Handler(object sender, TextChangedEventArgs e)
		{
			if (input.Text != null && fromRadix.Text != null && toRadix.Text != null)
			{
				WriteOutput();
			}
		}
	}
}