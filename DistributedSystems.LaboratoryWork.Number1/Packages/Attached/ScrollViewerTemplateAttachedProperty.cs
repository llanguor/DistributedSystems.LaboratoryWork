using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Attached
{
    internal class ScrollViewerTemplateAttachedProperty :
        ScrollViewer
    {

        #region DependencyProperties

        public static readonly DependencyProperty ScrollsColor =
            DependencyProperty.RegisterAttached(
                "ScrollsColor",
                typeof(Brush),
                typeof(ScrollViewerTemplateAttachedProperty),
                new PropertyMetadata(Brushes.LightGray)
                );

        #endregion

        #region Methods

        public static Brush GetScrollsColor(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ScrollsColor);
        }

        public static void SetScrollsColor(DependencyObject obj, object value)
        {
            obj.SetValue(ScrollsColor, value);
        }

        #endregion
    }
}
