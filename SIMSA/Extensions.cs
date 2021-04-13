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
		public static IEnumerable<T> Range<T>(this int n, Func<int, T> fn) => Enumerable.Range(0, n).Select(fn);
		public static void Range(this int n, Action<int> action)
		{
			for (int i = 0; i < n; ++i)
			{
				action(i);
			}
		}
		public static IEnumerable<string> DivideToUnicodeChars(this string s)
		{
			for (int i = 0; i < s.Length; ++i)
			{
				if (char.IsHighSurrogate(s[i]))
				{
					yield return s[i].ToString() + s[i + 1];
					++i;
				}
				else
				{
					yield return s[i].ToString();
				}
			}
		}
		public static IEnumerable<T> Forever<T>(this IEnumerable<T> e)
		{
			for (; ; )
			{
				foreach (var it in e)
				{
					yield return it;
				}
			}
		}
		public static IEnumerable<(T First, U Second)> Zip<T, U>(this IEnumerable<T> f, IEnumerable<U> s) => f.Zip(s, (a, b) => (a, b));
	}
}
