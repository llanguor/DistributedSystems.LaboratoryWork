using DistributedSystems.LaboratoryWork.Nuget.Converters.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace DistributedSystems.LaboratoryWork.Nuget.Converters
{
    public sealed class EqualsNullConverter :
        MultiValueConverterBase<EqualsNullConverter>
    {
        public override object? Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Length != 3)
            {
                throw new ArgumentException("Invalid count of values!");
            }

            return values[0] is null
                ? values[1]
                : values[2];
        }
    }
}
