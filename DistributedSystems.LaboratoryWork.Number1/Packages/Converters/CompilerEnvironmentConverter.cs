using DistributedSystems.LaboratoryWork.Nuget.Converters.Base;
using DistributedSystems.LaboratoryWork.Nuget.Dialog;
using DistributedSystems.LaboratoryWork.Number1.Packages.Types;
using DistributedSystems.LaboratoryWork.Number1.ViewModel.Dialogs;
using DryIoc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using static DistributedSystems.LaboratoryWork.Number1.Packages.Types.CompilerEnvironmentTypes;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Converters
{
    internal sealed class CompilerEnvironmentConverter :
       MultiValueConverterBase<CompilerEnvironmentConverter>
    {

        public override object? Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
        {
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
            if (value == null)
                return [];

            object programText = value;
            var exceptions = new List<Exception>();
            var instructions = new ObservableCollection<Instruction>();
            const string regexMask = @"^<(\d{1,3})>,<(\d{1,3})>,<(\d{1,3})>,<(\d{1,2})>$";
            int lineCount = 1;

            foreach (string instructionString in Regex.Split(programText.ToString()!, @"\s+"))
            {
                if (string.IsNullOrWhiteSpace(instructionString)) continue;
                Match match = Regex.Match(instructionString, regexMask);
                if (match.Success)
                {
                    var instruction = new Instruction();
                    instruction.Operand1 = int.Parse(match.Groups[1].Value);
                    instruction.Operand2 = int.Parse(match.Groups[2].Value);
                    instruction.Operand3 = int.Parse(match.Groups[3].Value);
                    instruction.Operation = int.Parse(match.Groups[4].Value);
                    instructions.Add(instruction);
                }
                else
                {
                    exceptions.Add(new Exception($"Incorrect format at line {lineCount}"));
                }
                ++lineCount;
            }

            var aggregateException = new AggregateException(exceptions);
            if (aggregateException.InnerExceptions.Count!=0)
            {
                
                //Select извлекает из объектов нужный параметр
                string allMessages = string.Join(
                    Environment.NewLine,
                    aggregateException.InnerExceptions.Select(ex => ex.Message));

                App.Container.Resolve<IDialogAware>().ShowDialog(DialogAwareParameters.Builder.Create()
                .ForDialogType<MessageDialogViewModel>()
                .AddParameter(MessageDialogViewModel.Parameters.PositiveCommand, null)
                .AddParameter(MessageDialogViewModel.Parameters.NegativeCommand, null)
                .AddParameter(MessageDialogViewModel.Parameters.DialogHostCommand, null)
                .AddParameter(MessageDialogViewModel.Parameters.Text, allMessages)
                .AddParameter(MessageDialogViewModel.Parameters.DialogTypeValue, MessageDialogTypes.DialogType.OkCancel)
                .AddParameter(MessageDialogViewModel.Parameters.ScrollViewerBackground, Colors.AliceBlue)
                .AddParameter(MessageDialogViewModel.Parameters.ScrollViewerHorizontalVisible, ScrollBarVisibility.Disabled)
                .AddParameter(MessageDialogViewModel.Parameters.ScrollViewerVerticalVisible, ScrollBarVisibility.Visible)
                .Build());

                return [DependencyProperty.UnsetValue];
            }

            return [instructions];
        }
    }
}
