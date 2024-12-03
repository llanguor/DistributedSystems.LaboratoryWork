using DistributedSystems.LaboratoryWork.Nuget.Converters.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystems.LaboratoryWork.Nuget.Converters
{
    internal class BitwiseConverter :
    MultiValueConverterBase<BitwiseConverter>
    {
        public enum Operators
        {
            /// <summary>
            /// Левый сдвиг
            /// </summary>
            LeftShift,
            /// <summary>
            /// Правый сдвиг
            /// </summary>
            RightShift,
            /// <summary>
            /// Логическое умножение
            /// </summary>
            LogicalAnd,
            /// <summary>
            /// Логическое сложение
            /// </summary>
            LogicalOr,
            /// <summary>
            /// Логическое исключающее или (XOR)
            /// </summary>
            LogicalExclusiveOr,
            /// <summary>
            /// Логическое отрицание (инверсия)
            /// </summary>
            Complement
        }


        public override object? Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
        {

            ArgumentNullException.ThrowIfNull(parameter);

            if (!Enum.IsDefined(typeof(Operators), parameter))
            {
                throw new NotSupportedException("This operation is not supported!");
            }

            var @operator = (Operators)parameter;
            if (@operator is Operators.Complement && values.Length != 1 || values.Length != 2)
            {
                throw new ArgumentException("Invalid count of values!");
            }

            dynamic leftOperand = values[0] ?? throw new ArgumentNullException("First parameter was null");
            dynamic rightOperand = values[1];
            if (@operator is not Operators.Complement)
            {
                throw new ArgumentNullException("Second parameter was null");
            }

            switch (@operator)
            {
                case Operators.LeftShift: 
                    return leftOperand << rightOperand;
                case Operators.RightShift:
                    return leftOperand >> rightOperand;
                case Operators.LogicalAnd:
                    return leftOperand & rightOperand;
                case Operators.LogicalOr:
                    return leftOperand | rightOperand;
                case Operators.LogicalExclusiveOr:
                    return leftOperand ^ rightOperand;
                case Operators.Complement:
                    return ~leftOperand;

                default:
                    throw new ArgumentOutOfRangeException(nameof(parameter));
            }
        }
    }
}
