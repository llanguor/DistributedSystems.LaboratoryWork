using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Attached
{
    internal class ImageButtonTemplateAttachedProperty :
        Button
    {

        #region DependencyProperties

        public static readonly DependencyProperty Source =
            DependencyProperty.RegisterAttached(
                "ImageSource",
                typeof(ImageSource),
                typeof(ImageButtonTemplateAttachedProperty),
                new PropertyMetadata(null)
                );

        public static readonly DependencyProperty ImageScaleX =
            DependencyProperty.RegisterAttached(
                "ImageScaleX",
                typeof(double),
                typeof(ImageButtonTemplateAttachedProperty));

        public static readonly DependencyProperty ImageScaleY =
            DependencyProperty.RegisterAttached(
                "ImageScaleY",
                typeof(double),
                typeof(ImageButtonTemplateAttachedProperty));

        #endregion

        #region Methods

        public static ImageSource GetImageSource(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(Source);
        }

        public static void SetImageSource(DependencyObject obj, object value)
        {
            obj.SetValue(Source, value);
        }

        public static double GetImageScaleX(DependencyObject obj)
        {
            return (double)obj.GetValue(ImageScaleX);
        }

        public static void SetImageScaleX(DependencyObject obj, object value)
        {
            obj.SetValue(ImageScaleX, value);
        }

        public static double GetImageScaleY(DependencyObject obj)
        {
            return (double)obj.GetValue(ImageScaleX);
        }

        public static void SetImageScaleY(DependencyObject obj, object value)
        {
            obj.SetValue(ImageScaleX, value);
        }

        #endregion

    }
}
