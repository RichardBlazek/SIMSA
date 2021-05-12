using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using SIMSA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditAlphabet : ContentPage
	{
		Task EditAndQuit(Alphabets alphabets, Action<Alphabets> saveAlphabets, int i)
		{
			var newLetters = letters.Text.DivideToUnicodeChars().ToImmutableArray();
			saveAlphabets(alphabets.Update(i, new CustomAlphabet(newLetters, name.Text)));
			return Navigation.PopAsync(false);
		}

		Task RemoveAndQuit(Alphabets alphabets, Action<Alphabets> saveAlphabets, int i)
		{
			saveAlphabets(alphabets.Remove(i));
			return Navigation.PopAsync(false);
		}
		public EditAlphabet(Alphabets alphabets, Action<Alphabets> saveAlphabets, int i)
		{
			InitializeComponent();
			letters.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeCharacter);

			name.Text = alphabets.Custom[i].Name;
			letters.Text = alphabets.Custom[i].Cat();

			confirm.Clicked += async (o, a) => await EditAndQuit(alphabets, saveAlphabets, i);
			delete.Clicked += async (o, a) => await RemoveAndQuit(alphabets, saveAlphabets, i);
		}
	}
}