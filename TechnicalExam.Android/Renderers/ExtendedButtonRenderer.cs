using System;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using TechnicalExam.Renderers;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using TechnicalExam.Droid.Renderers;

[assembly: ExportRenderer(typeof(ExtendedButton), typeof(ExtendedButtonRenderer))]
namespace TechnicalExam.Droid.Renderers
{
    public class ExtendedButtonRenderer : ButtonRenderer
    {
        public ExtendedButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            var control = e.NewElement as ExtendedButton;
            if (control != null)
            {
                var backgroundColor = ((Color)(Element as ExtendedButton).Style.Setters.FirstOrDefault(item => item.Property.PropertyName == "BackgroundColor").Value).ToAndroid();
                Control.Background.SetColorFilter(backgroundColor, Android.Graphics.PorterDuff.Mode.Src);
                var textColor = (Color)(Element as ExtendedButton).Style.Setters.FirstOrDefault(item => item.Property.PropertyName == "TextColor").Value;
                Control.SetTextColor(textColor.ToAndroid());
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "TextColor")
            {
                if (!Control.Enabled)
                {
                    var textColor = (Color)(Element as ExtendedButton).Style.Setters.FirstOrDefault(item => item.Property.PropertyName == "TextColor").Value;
                    Control.SetTextColor(textColor.ToAndroid());
                }
            }
            if (e.PropertyName == "Style")
            {
                var backgroundColor = ((Color)(Element as ExtendedButton).Style.Setters.FirstOrDefault(item => item.Property.PropertyName == "BackgroundColor").Value).ToAndroid();
                Control.Background.SetColorFilter(backgroundColor, Android.Graphics.PorterDuff.Mode.Src);
                var textColor = (Color)(Element as ExtendedButton).Style.Setters.FirstOrDefault(item => item.Property.PropertyName == "TextColor").Value;
                Control.SetTextColor(textColor.ToAndroid());
            }
        }
    }
}
