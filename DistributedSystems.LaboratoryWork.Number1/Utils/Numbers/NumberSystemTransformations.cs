using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DistributedSystems.LaboratoryWork.Number1.Utils.Numbers
{
    public sealed class NumberSystemTransformations
    {
        public static int ConvertNumberFromBase(string input, int fromBase)
        {
            if (fromBase < 2 || fromBase > 16) 
                throw new ArgumentException("Incorrect number system");

            if (fromBase > 10)
            {
                if (!input.All(char.IsLetterOrDigit))
                    throw new ArgumentException("Incorrect input");
            }
            else
            {
                if (!input.All(char.IsDigit))
                    throw new ArgumentException("Incorrect input");
            }


            const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            input = input.ToUpper(); // Приводим к верхнему регистру для обработки букв

            int result = 0;
            int power = 1; // Начинаем с младшего разряда

            for (int i = input.Length - 1; i >= 0; i--)
            {
                char c = input[i];
                int digitValue = digits.IndexOf(c);

                if (digitValue == -1 || digitValue >= fromBase)
                {
                    throw new ArgumentException($"Symbol '{c}' is incorrect for base {fromBase}.");
                }

                result += digitValue * power;
                power *= fromBase; 
            }

            return result;
        }
        public static string ConvertNumberToBase(int input, int toBase)
        {
            if (toBase < 2 || toBase > 16)
            {
                throw new ArgumentException("Incorrect number system");
            }

            if (input == 0)
            {
                return "0";
            }

            const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            bool isNegative = input < 0;
            input = Math.Abs(input);

            string result = "";

            while (input > 0)
            {
                int remainder = input % toBase;
                result = digits[remainder] + result;
                input /= toBase;
            }

            return isNegative ? "-" + result : result;
        }

        public static string ConvertNumber(string input, int fromBase, int toBase)
        {
            return 
                ConvertNumberToBase(
                    ConvertNumberFromBase(input, fromBase),
                    toBase)
                .ToUpper();
        }
    }
}
