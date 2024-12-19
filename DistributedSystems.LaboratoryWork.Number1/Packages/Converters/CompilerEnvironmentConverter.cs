using DistributedSystems.LaboratoryWork.Nuget.Converters.Base;
using DistributedSystems.LaboratoryWork.Number1.Packages.Types;
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
    internal sealed class CompilerEnvironmentConverter :
       MultiValueConverterBase<CompilerEnvironmentConverter>
    {
        public override object? Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
        {
           /* 
            if (values.Length != 1)
            {
               //throw new ArgumentException("Invalid count of values!");
            }
           */

            string res = "";
            var instructions = (ObservableCollection<Instruction>)values[0];
            foreach (var instruction in instructions)
            {
                res += $"<{instruction.Operand1}>,<{instruction.Operand2}>,<{instruction.Operand3}>,<{instruction.Operation}>\r\n";
            }
            return res;
        }

        public override object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
        {
            //TODO: Check: если значение операции больше доступного. если значение операнда больше доступного. если ничего внутри нет (regex). Если в value null или нет параметров
            //TODO: Replace to regex; 
            //TODO: throw exceptions
            if (value==null)
            {
                throw new ArgumentException("Invalid count of values!");
            }

            var instructions = new ObservableCollection<Instruction>();

            string programString = value.ToString()!;

            foreach (string instructionString in programString.Split("\r\n"))
            {
                //TODO: check by regex
                if (instructionString.Length < 15) continue;
                var instructionPart = instructionString.Substring(1, instructionString.Length - 2).Split(">,<");

                var instruction = new Instruction();
                instruction.Operand1 = int.Parse(instructionPart[0]);
                instruction.Operand2 = int.Parse(instructionPart[1]);
                instruction.Operand3 = int.Parse(instructionPart[2]);
                instruction.Operation = int.Parse(instructionPart[3]);
                instructions.Add(instruction);
            }

            return [instructions];
        }
    }
}
