using System;
using SIMSA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Views
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
			letters.Text = alphabets.Custom[i].ToString();
			letters.TextChanged += (o, a) => letters.Text = letters.Text.ToUpperInvariant();

			confirm.Command = Action(() => saveAlphabets(alphabets.Update(i, new CustomAlphabet(letters.Text, name.Text))));
			delete.Command = Action(() => saveAlphabets(alphabets.Remove(i)));
		}
	}
}