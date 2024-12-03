using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Attached
{
    public class ImageButtonTemplateAttachedProperty :
        Button
    {
        public static readonly DependencyProperty Source =
            DependencyProperty.RegisterAttached(
                "Source",
                typeof(string),
                typeof(ImageButtonTemplateAttachedProperty)
                );

        public static string GetSource(DependencyObject obj)
        {
            return (string)obj.GetValue(Source);
        }

        public static void SetSource(DependencyObject obj, object value)
        {
             obj.SetValue(Source, value);
        }

    }
}
