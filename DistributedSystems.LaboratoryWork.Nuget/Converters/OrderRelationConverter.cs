using DistributedSystems.LaboratoryWork.Nuget.Converters.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DistributedSystems.LaboratoryWork.Nuget.Converters
{
    public sealed class OrderRelationConverter :
         MultiValueConverterBase<OrderRelationConverter>
    {

        #region Nested

        public class OrderRelationResult
        {
            public bool Antisymmetric { get; set; } = true;
            public bool Reflexivity { get; set; } = true;
            public bool Transitivity { get; set; } = true;
        }

        #endregion

        #region Overrides

        public override object? Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Length != 1)
            {
                throw new ArgumentException("Invalid count of values!");
            }

            bool[,] relation = (bool[,])values[0];
            int n = relation.GetLength(0);
            OrderRelationResult orderRelationResult = new OrderRelationResult();

            // Проверка рефлексивности
            for (int i = 0; i < n; i++)
            {
                if (!relation[i, i])
                {
                    orderRelationResult.Reflexivity = false;
                }
            }

            // Проверка антисимметричности
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j && relation[i, j] && relation[j, i])
                    {
                        orderRelationResult.Antisymmetric = false;
                    }
                }
            }

            // Проверка транзитивности
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (relation[i, j])
                    {
                        for (int k = 0; k < n; k++)
                        {
                            if (relation[j, k] && !relation[i, k])
                            {
                                orderRelationResult.Transitivity = false;
                                return false;
                            }
                        }
                    }
                }
            }

            return orderRelationResult;
        }

        #endregion

    }
}
