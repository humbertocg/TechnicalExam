using System;
using System.Linq;
using Foundation;
using TechnicalExam.iOS.Renderers;
using TechnicalExam.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedButton), typeof(ExtendedButtonRenderer))]
namespace TechnicalExam.iOS.Renderers
{
    public class ExtendedButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Element != null && (Element as ExtendedButton).Style != null)
            {
                var textColor = (Color)(Element as ExtendedButton).Style.Setters.FirstOrDefault(item => item.Property.PropertyName == "TextColor").Value;
                var title = new NSAttributedString(e.NewElement.Text,
                                                   foregroundColor: textColor.ToUIColor());
                Control.SetAttributedTitle(title, UIControlState.Disabled);
            }
        }
    }
}