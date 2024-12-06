using DistributedSystems.LaboratoryWork.Number1.Packages.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.TemplateSelectors
{
    internal class TemplateSelector_LetterKeyboard_ButtonsType:
        DataTemplateSelector
    {
        public override DataTemplate? SelectTemplate(object item, DependencyObject container)
        {

            ArgumentNullException.ThrowIfNull(item);

            if (container is not FrameworkElement frameworkElement)
            {
                throw new ArgumentException($"Incorrect argument: {nameof(container)}");
            }

            
            switch (item.ToString())
            {
                case LetterKeyboardTypes.ButtonTags.Language:
                    return frameworkElement.FindResource("LanguageTemplate") as DataTemplate;
                case LetterKeyboardTypes.ButtonTags.Void:
                    return frameworkElement.FindResource("VoidTemplate") as DataTemplate;
                case LetterKeyboardTypes.ButtonTags.ClearAll:
                    return frameworkElement.FindResource("ClearAllTemplate") as DataTemplate;
                case LetterKeyboardTypes.ButtonTags.Clear:
                    return frameworkElement.FindResource("ClearTemplate") as DataTemplate;
                case LetterKeyboardTypes.ButtonTags.CapsLock:
                    return frameworkElement.FindResource("CapsLockTemplate") as DataTemplate;
                case LetterKeyboardTypes.ButtonTags.Enter:
                    return frameworkElement.FindResource("EnterTemplate") as DataTemplate;
                default:
                    return frameworkElement.FindResource("NumericTemplate") as DataTemplate;
            }
        }
    }
}
