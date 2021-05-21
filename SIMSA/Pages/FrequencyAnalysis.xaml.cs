using System;
using System.Collections.Immutable;
using System.Linq;
using SIMSA.Models;
using SIMSA.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FrequencyAnalysis : ContentPage, IConfigurable
	{
		public Config Config { get; set; }
		FrequencyAnalyser.Language language;
		public FrequencyAnalysis(Config config)
		{
			InitializeComponent();
			Config = config;
			input.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeCharacter);
			SetLanguage(FrequencyAnalyser.Language.English);
		}
		static FlexLayout Flex(View first, View second) => new FlexLayout
		{
			JustifyContent = FlexJustify.SpaceBetween,
			Margin = new Thickness(10, 0),
			Children = { first, second }
		};
		static void DrawOutput(StackLayout layout, ImmutableDictionary<char, double> frequencies)
		{
			int i = 0;
			foreach (var (sym, freq) in frequencies.OrderByDescending(pair => pair.Value))
			{
				var letter = new Label { Text = sym.ToString(), HorizontalTextAlignment = TextAlignment.Center };
				var percent = new Label { Text = (freq * 100).ToString("F2") + " %", HorizontalTextAlignment = TextAlignment.Center };
				if (i < layout.Children.Count)
				{
					var dest = (layout.Children[i] as FlexLayout)!.Children;
					(dest[0], dest[1]) = (letter, percent);
				}
				else
				{
					layout.Children.Add(Flex(letter, percent));
				}
				++i;
			}
			while (i < layout.Children.Count)
			{
				layout.Children.RemoveAt(layout.Children.Count - 1);
			}
		}
		void SetLanguage(FrequencyAnalyser.Language lang)
		{
			language = lang;
			languageSwitch.Text = lang switch { FrequencyAnalyser.Language.English => AppResources.English, FrequencyAnalyser.Language.Czech => AppResources.Czech, _ => AppResources.CzechDiacritics };
			DrawOutput(languageStats, FrequencyAnalyser.Statistics[lang]);
		}
		void SwitchLanguage(object sender, EventArgs e) => SetLanguage((FrequencyAnalyser.Language)(((int)language + 1) % 3));
		void RunAnalysis(object sender, EventArgs e) => DrawOutput(inputStats, FrequencyAnalyser.Analyse(input?.Text ?? ""));
	}
}