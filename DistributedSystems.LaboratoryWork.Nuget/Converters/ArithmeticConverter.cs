using System.Globalization;
using DistributedSystems.LaboratoryWork.Nuget.Converters.Base;

namespace DistributedSystems.LaboratoryWork.Nuget.Converters;


public sealed class ArithmeticConverter :
    MultiValueConverterBase<ArithmeticConverter>
{

    #region Nested

    public enum Operators
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        RemainderDivide
    }

    #endregion

    #region Overrides

    public override object? Convert(
        object?[] values,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        if (values.Length != 2)
        {
            throw new ArgumentException("Invalid count of values!");
        }

        ArgumentNullException.ThrowIfNull(parameter);

        if (!Enum.IsDefined(typeof(Operators), parameter))
        {
            throw new NotSupportedException("This operation is not supported!");
        }

        var @operator = (Operators)parameter;
        dynamic leftOperand = values[0] ?? throw new ArgumentNullException("First parameter was null");
        dynamic rightOperand = values[1] ?? throw new ArgumentNullException("Second parameter was null");

        switch (@operator)
        {
            case Operators.Plus:
                return leftOperand + rightOperand;
            case Operators.Minus:
                return leftOperand - rightOperand;
            case Operators.Multiply:
                return leftOperand * rightOperand;
            case Operators.Divide:
                return leftOperand / rightOperand;
            case Operators.RemainderDivide:
                return leftOperand % rightOperand;
            default:
                throw new ArgumentOutOfRangeException(nameof(parameter));
        }
    }

    #endregion

}