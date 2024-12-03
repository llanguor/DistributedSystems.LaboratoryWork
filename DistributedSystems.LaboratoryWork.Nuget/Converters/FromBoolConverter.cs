using System.Globalization;
using DistributedSystems.LaboratoryWork.Nuget.Converters.Base;

namespace DistributedSystems.LaboratoryWork.Nuget.Converters;

/// <summary>
/// 
/// </summary>
public sealed class FromBoolConverter :
    MultiValueConverterBase<FromBoolConverter>
{

    public override object? Convert(
        object?[] values,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        if (values.Length != 3)
        {
            throw new ArgumentException("Invalid count of values!");
        }

        ArgumentNullException.ThrowIfNull(values[0]);

        return (bool)values[0]!
            ? values[1]
            : values[2];
    }
}