using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystems.LaboratoryWork.Number1.Utils.Numbers
{
    public sealed class NumberToBytesTransformations
    {
        //TODO: change to uint?

        public static long ConvertToBytes(int operand1, int operand2, int operand3, int operation)
        {
            long res = operand3;
            res <<= 9;
            res |= operand2;
            res <<= 9;
            res |= operand1;
            res <<= 5;
            res |= operation;
            return res;
        }

        public static void ConvertToValues(long input, out int operand1, out int operand2, out int operand3, out int operation)
        {
            operation = (int)(input & 31);
            input >>= 5;
            operand1 = (int)(input & 511);
            input >>= 9;
            operand2 = (int)(input & 511);
            input >>= 9;
            operand3 = (int)(input & 511);
        }
    }
}
