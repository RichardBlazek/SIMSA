using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("SIMSA.Effects")]
[assembly: ExportEffect(typeof(SIMSA.Droid.Effects.HideKeyboard), nameof(SIMSA.Effects.HideKeyboard))]
namespace SIMSA.Droid.Effects
{
	public class HideKeyboard : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                if (Control is Android.Widget.EditText editText)
                {
                    editText.ShowSoftInputOnFocus = false;
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(nameof(HideKeyboard) + " failed to attached: " + ex.Message);
            }
        }
        protected override void OnDetached() { }
    }
}