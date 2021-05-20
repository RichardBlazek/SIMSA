﻿[assembly: Xamarin.Forms.ExportRenderer(typeof(Xamarin.Forms.Entry), typeof(SIMSA.Droid.Code.EntryCustomRenderer))]
namespace SIMSA.Droid.Code
{
	public class EntryCustomRenderer : Xamarin.Forms.Platform.Android.EntryRenderer
    {
        public EntryCustomRenderer(Android.Content.Context ctx) : base(ctx) { }
		protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && e.NewElement != null)
            {
                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
                {
                    Control.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.White);
                }
                else
                {
					Control.Background.SetColorFilter(Android.Graphics.Color.White, Android.Graphics.PorterDuff.Mode.SrcAtop);
                }
            }
        }
    }
}