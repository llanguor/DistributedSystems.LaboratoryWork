using DistributedSystems.LaboratoryWork.Nuget.Converters.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DistributedSystems.LaboratoryWork.Number1.Packages.Types.CompilerEnvironmentTypes;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Converters
{
    internal class SpinnerDialogConverter :
        ValueConverterBase<SpinnerDialogConverter>
    {
        public override object? Convert(object value, Type targetType, object? parameter, CultureInfo culture)
        {
            string line = value.ToString() ?? throw new ArgumentException("Null value is invalid");
            if(!int.TryParse(line, out var number))
            {
                throw new ArgumentException("Incorrect input value type");
            }

            return new string('.', number);
        }
    }
}
