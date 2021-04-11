using System;
using System.Collections.Immutable;
using System.Linq;
using SIMSA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditAlphabet : ContentPage
	{
		Command Action(Action callback) => new Command(async () =>
		{
			callback();
			_ = await Navigation.PopAsync(false);
		});
		public EditAlphabet(Alphabets alphabets, Action<Alphabets> saveAlphabets, int i)
		{
			InitializeComponent();
			name.Text = alphabets.Custom[i].Name;
			letters.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeCharacter);
			letters.Text = alphabets.Custom[i].Cat(",");

			confirm.Command = Action(() => saveAlphabets(alphabets.Update(i, new CustomAlphabet(letters.Text.Split(",").Select(s => s.Trim()).Where(s => s.Length > 0).ToImmutableArray(), name.Text, 0))));
			delete.Command = Action(() => saveAlphabets(alphabets.Remove(i)));
		}
	}
}