using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DistributedSystems.LaboratoryWork.Number1.Packages.Controls.Types;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Controls.TemplateSelectors
{
    class TemplateSelector_NumericKeyboard_ButtonsType:
        DataTemplateSelector
    {

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {

            ArgumentNullException.ThrowIfNull(item);

            if(container is not FrameworkElement frameworkElement)
            {
                throw new ArgumentException($"Incorrect argument: {nameof(container)}");
            }

            if (item.ToString() == NumericKeyboardTypes.ButtonTags.ClearButtonTag)
            {
                return frameworkElement.FindResource("ClearTemplate") as DataTemplate ?? base.SelectTemplate(item, container);
            }

            if (item.ToString() == NumericKeyboardTypes.ButtonTags.VoidTag)
            {
                return frameworkElement.FindResource("VoidTemplate") as DataTemplate ?? base.SelectTemplate(item, container);
            }

            return frameworkElement.FindResource("NumericTemplate") as DataTemplate ?? base.SelectTemplate(item, container);
        }
    }
}
