using System;
using SIMSA.Models;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using TouchTracking;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SIMSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FlagSemaphore : ContentPage, IConfigurable
	{
		public Config Config { get; set; }

		FlagSemaphoreText text;

		void SetText(FlagSemaphoreText newText)
		{
			text = newText;
			output.Text = text.ToString();
			canvas.InvalidateSurface();
		}

		static int ToDirection(double x, double y) => ((int)Math.Round(Math.Atan2(y, x) * 4 / Math.PI + 2)).Mod(8);
		static float ToCoordX(int direction) => MathF.Cos((direction - 2) * MathF.PI / 4);
		static float ToCoordY(int direction) => MathF.Sin((direction - 2) * MathF.PI / 4);

		void SemaphoreTouchHandler(object sender, TouchActionEventArgs args)
		{
			if (args.Type == TouchActionType.Pressed)
			{
				SetText(text.SetFlag(ToDirection(args.Location.X - canvas.Width / 2, args.Location.Y - canvas.Height / 2)));
			}
		}

		void SemaphorePaintSurfaceHandler(object sender, SKPaintSurfaceEventArgs args)
		{
			var info = args.Info;
			var surface = args.Surface;
			var canvas = surface.Canvas;

			var blackLine = new SKPaint { Color = new SKColor(0, 0, 0), StrokeWidth = 3 };
			float radius = Math.Min(info.Width, info.Height) / 2f;

			canvas.Clear();
			canvas.DrawCircle(info.Width / 2f, info.Height / 2f, radius, new SKPaint { Color = new SKColor(255, 255, 255) });
			canvas.DrawLine(info.Width / 2f, info.Height / 2f, ToCoordX(text[^1, false]) * radius + info.Width / 2, ToCoordY(text[^1, false]) * radius + info.Height / 2, blackLine);
			canvas.DrawLine(info.Width / 2f, info.Height / 2f, ToCoordX(text[^1, true]) * radius + info.Width / 2, ToCoordY(text[^1, true]) * radius + info.Height / 2, blackLine);
		}

		public FlagSemaphore(Config config, FlagSemaphoreText initText)
		{
			InitializeComponent();

			Config = config;
			text = initText;
			SetText(text);

			confirm.Clicked += (o, a) => SetText(text.Add());
			turn.Clicked += (o, a) => SetText(text.Turn(1));
			backspace.Clicked += (o, a) => SetText(text.Pop());
		}
	}
}