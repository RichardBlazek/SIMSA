using System;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using SIMSA.Models;
using Xamarin.Forms;

namespace SIMSA.ViewModels
{
	public class ColorConverterVM : ViewModelBase
	{
		static readonly ImmutableArray<IColorModel> models = ImmutableArray.Create<IColorModel>(new RGBColorModel(), new HTMLColorModel(), new CMYKColorModel(), new HSVColorModel(), new HSLColorModel());
		public ImmutableArray<string> ModelNames { get; }
		public ObservableCollection<EntryVM> Inputs { get; private set; }
		int selected = 0;
		RGBColor RGBColor => models[selected].ToRGB(Inputs.Select(inp => inp.Text).ToImmutableArray());
		public Color Color => RGBColor.ToXamarin;
		void InputChanged(int i)
		{
			Inputs[i].Text = models[selected].Filter(Inputs[i].Text, i);
			PropertyChange("Color");
		}
		ObservableCollection<EntryVM> CreateInputs(IColorModel model, RGBColor color)
		{
			var values = model.FromRGB(color);
			return new ObservableCollection<EntryVM>(model.Names.Select((name, i) => new EntryVM(name, values[i], () => InputChanged(i))));
		}
		public string SelectedModel
		{
			get => models[selected].Name;
			set
			{
				int i = Math.Clamp(ModelNames.IndexOf(value), 0, ModelNames.Length - 1);
				Inputs = CreateInputs(models[i], RGBColor);
				ChangePropertyUI(ref selected, i, SelectedModel, ModelNames[i], "SelectedModel", "Color", "Inputs");
			}
		}
		public ColorConverterVM()
		{
			ModelNames = models.Select(m => m.Name).ToImmutableArray();
			Inputs = CreateInputs(models[selected], new RGBColor(0, 0, 0));
		}
	}
}
