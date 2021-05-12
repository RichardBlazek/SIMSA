using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("SIMSA.Effects")]
[assembly: ExportEffect(typeof(SIMSA.iOS.Effects.HideKeyboard), nameof(SIMSA.Effects.HideKeyboard))]
namespace SIMSA.iOS.Effects
{
	public class HideKeyboard : PlatformEffect
	{
		protected override void OnAttached()
		{
			try
			{
				if (Control is UIKit.UITextField textField)
				{
					textField.InputView = new UIKit.UIView();
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