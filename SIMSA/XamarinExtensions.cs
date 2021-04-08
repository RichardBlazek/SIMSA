using System;
using Xamarin.Forms;

namespace SIMSA
{
	public static class XamarinExtensions
	{
		public static void SetText(this Entry entry, string text, int position)
		{
			entry.Text = text;

			// If you do not unfocus it, Effects.HideKeyboard may not work and the keyboard might appear
			// It happens only sometimes, but this call prevents it
			entry.Unfocus();

			// You may think that this code does two times the same thing and I thought so as well
			// However, if you remove one of the two lines, the cursor position will be set to the end
			// My theory is that the first line causes re-focusing with cursor at the end
			// and the second line moves the cursor
			entry.CursorPosition = Math.Clamp(position, 0, text.Length);
			entry.CursorPosition = Math.Clamp(position, 0, text.Length);
		}
	}
}
