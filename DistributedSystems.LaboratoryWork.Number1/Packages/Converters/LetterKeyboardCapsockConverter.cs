using DistributedSystems.LaboratoryWork.Nuget.Converters.Base;
using DistributedSystems.LaboratoryWork.Number1.Packages.Types;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Converters
{
    internal sealed class LetterKeyboardCapslockConverter :
        MultiValueConverterBase<LetterKeyboardCapslockConverter>
    {
        public override object? Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Length != 2)
            {
                throw new ArgumentException("Invalid count of values!");
            }

            bool capsLockOn = (bool)values[0];
            string buttonContent = values[1].ToString() ?? throw new ArgumentException(nameof(values));

            return capsLockOn ?
                 buttonContent.ToUpper() :
                 buttonContent.ToLower();
        }
    }
}
