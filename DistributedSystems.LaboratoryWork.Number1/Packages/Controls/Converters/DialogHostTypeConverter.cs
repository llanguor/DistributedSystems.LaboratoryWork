using DistributedSystems.LaboratoryWork.Nuget.Converters.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DistributedSystems.LaboratoryWork.Nuget.Converters.ArithmeticConverter;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Controls.Converters
{
    public sealed class DialogHostTypeConverter:
        MultiValueConverterBase<DialogHostTypeConverter>
    {
        public enum DialogType
        {
            Ok = 1,
            OkCancel = 2,
            YesNo = 3
        }

        public override object? Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Length != 2)
            {
                throw new ArgumentException("Invalid count of values!");
            }

            bool buttonPositive = (bool)values[1];
            var type = (DialogType)values[0];

            switch (type) 
            {
                case DialogType.Ok:
                    return buttonPositive ? "Ok" : "";
                case DialogType.OkCancel:
                    return buttonPositive ? "Ok" : "Cancel";
                case DialogType.YesNo:
                    return buttonPositive ? "Yes" : "No";
                default:
                    throw new ArgumentOutOfRangeException(nameof(parameter));
            }
        }
    }
}
