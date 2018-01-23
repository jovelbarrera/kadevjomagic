using System;
using MagicKadevjo.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ProgressBar), typeof(DroidCustomProgressBar))]
namespace MagicKadevjo.Droid.Renderers
{
    public class DroidCustomProgressBar : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);

            //Control.Background = Resources.GetDrawable("progress_background_style");
            Control.ProgressDrawable = Resources.GetDrawable("progress_style");
        }
    }
}