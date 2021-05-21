﻿[assembly: Xamarin.Forms.ExportRenderer(typeof(Xamarin.Forms.Editor), typeof(SIMSA.Droid.Code.EditorCustomRenderer))]
namespace SIMSA.Droid.Code
{
    public class EditorCustomRenderer : Xamarin.Forms.Platform.Android.EditorRenderer
    {
        public EditorCustomRenderer(Android.Content.Context ctx) : base(ctx) { }
        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Editor> e)
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