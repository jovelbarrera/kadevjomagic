using System.Drawing;
using CoreAnimation;
using CoreGraphics;
using MagicKadevjo.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(iOSProgressBar))]
namespace MagicKadevjo.iOS.Renderers
{
    public class iOSProgressBar : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            Control.TrackImage = BackgroundUIImage(Color.FromHex("#844D20"), Color.FromHex("#AA7543"));
            Control.ProgressImage = BackgroundUIImage(Color.FromHex("#55B4B8"), Color.FromHex("#0D5677"));

            Control.Layer.MasksToBounds = true;
            Control.ClipsToBounds = true;
            Control.Layer.CornerRadius = 3;

            //UIView view = new UIView(new CGRect(0, 0, Control.Layer.Frame.Width, Control.Layer.Frame.Height));
            //view.Layer.CornerRadius = 3;
            //view.BackgroundColor = Color.FromHex("#FFC75A").ToUIColor();
            ////view.Transform = CGAffineTransform.MakeScale(1, 6);
            //AddSubview(view);
            ////InsertSubview(view, 0);
            ////Control.Layer.Frame = new CGRect(6, 6, Control.Layer.Bounds.Width, Control.Layer.Bounds.Height);
        }

        private UIImage BackgroundUIImage(Color start, Color end)
        {
            UIView view = new UIView(new CGRect(0, 0, 1, 1));
            CAGradientLayer gradient = new CAGradientLayer();

            gradient.Frame = view.Bounds;
            gradient.Colors = new CGColor[] {
                start.ToCGColor(),
                end.ToCGColor()
            };

            view.Layer.InsertSublayer(gradient, 0);

            UIGraphics.BeginImageContextWithOptions(view.Bounds.Size, true, 0);
            CGContext context = UIGraphics.GetCurrentContext();
            view.Layer.RenderInContext(context);
            UIImage snapshotImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            Control.ProgressImage = snapshotImage;
            return snapshotImage;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            CGAffineTransform transform = CGAffineTransform.MakeScale(1, 6);
            Transform = transform;
        }
    }
}
