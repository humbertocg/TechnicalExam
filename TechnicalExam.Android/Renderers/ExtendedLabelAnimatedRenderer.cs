using System;
using Android.Content;
using Android.Text;
using TechnicalExam.Droid.Renderers;
using TechnicalExam.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedLabelAnimated), typeof(ExtendedLabelAnimatedRenderer))]
namespace TechnicalExam.Droid.Renderers
{
    public class ExtendedLabelAnimatedRenderer : LabelRenderer
    {
        public ExtendedLabelAnimatedRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetSingleLine(true);
                Control.Selected = true;
                Control.SetMarqueeRepeatLimit(-1);
                Control.Ellipsize = TextUtils.TruncateAt.Marquee;
            }
        }
    }
}
