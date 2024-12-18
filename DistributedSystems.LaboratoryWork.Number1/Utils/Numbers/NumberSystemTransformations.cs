using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystems.LaboratoryWork.Number1.Utils.Numbers
{
    internal class NumberSystemTransformations
    {
        public static Int32 ConvertNumberFromBase(string input, int fromBase)
        {
            return Convert.ToInt32(input, fromBase);
        }
        public static string ConvertNumberToBase(int input, int toBase)
        {
            return Convert.ToString(input, toBase).ToUpper();
        }

        public static string ConvertNumber(string input, int fromBase, int toBase)
        {
            return 
                ConvertNumberToBase(
                    ConvertNumberFromBase(input, fromBase),
                    toBase
                    ).ToUpper();
        }
    }
}
