using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace SIMSA
{
	public static class Extensions
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

		public static string Cat<T>(this IEnumerable<T> e, string str = "") => string.Join(str, e.Select(it => it?.ToString() ?? ""));
		public static string Cat(this IEnumerable<string> e, string str = "") => string.Join(str, e);
		public static int Mod(this int n, int d) => (n % d + d) % d;
	}
}
