using DistributedSystems.LaboratoryWork.Nuget.Converters.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistributedSystems.LaboratoryWork.Number1.Packages.Types;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Converters
{
    public sealed class MessageDialogTypeConverter:
        MultiValueConverterBase<MessageDialogTypeConverter>
    {

        public override object? Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Length != 2)
            {
                throw new ArgumentException("Invalid count of values!");
            }

            bool buttonPositive = (bool)values[1];
            var type = (MessageDialogTypes.DialogType)values[0];

            switch (type) 
            {
                case MessageDialogTypes.DialogType.Ok:
                    return buttonPositive ? "Ok" : "";
                case MessageDialogTypes.DialogType.OkCancel:
                    return buttonPositive ? "Ok" : "Cancel";
                case MessageDialogTypes.DialogType.YesNo:
                    return buttonPositive ? "Yes" : "No";
                default:
                    throw new ArgumentOutOfRangeException(nameof(parameter));
            }
        }
    }
}
