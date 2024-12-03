using DistributedSystems.LaboratoryWork.Nuget.Converters.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystems.LaboratoryWork.Nuget.Converters
{
    public sealed class EqualsConverter :
        MultiValueConverterBase<EqualsConverter>
    {
        public override object? Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Length != 4)
            {
                throw new ArgumentException("Invalid count of values!");
            }

            return !values[0].Equals(values[1])
                ? values[2]
                : values[3];
        }
    }
}
