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
			letters.Text = alphabets.Custom[i].ToString();

			confirm.Command = Action(() => saveAlphabets(alphabets.Update(i, new CustomAlphabet(letters.Text.Select(c => c.ToString()).ToImmutableArray(), name.Text))));
			backspace.Command = Action(() => saveAlphabets(alphabets.Remove(i)));
		}
	}
}