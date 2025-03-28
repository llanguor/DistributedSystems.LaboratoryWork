﻿using DistributedSystems.LaboratoryWork.Nuget.Converters.Base;
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

            if (values.Length < 1)
            {
                throw new ArgumentException("Invalid count of values!");
            }

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
            if (value is null)
                return Array.Empty<object>();

            object programText = value;
            var exceptions = new List<Exception>();
            var instructions = new ObservableCollection<Instruction>();

            // ^ - начало регулярки
            //\d - число
            //\d{1,3} - число от 1 до 3 символов
            // скобки - сохранить значения чтобы можно было потом ссчитать ниже то что лежит внутри
            // так же скобки позволяют раздробить выполнение на части. Например <111> - ок, <111>,<111> - ок
            //      В таком случае мы ставим ?: - говорим о том, что не надо сохранять переменные
            //все остальные символы - просто часть маски. Например >,< и тд
            //-? перед числом говорит о том что там может быть минус а может не быть

            //тут маска такая:
            // <число от 1 до 3 знаков>,<число от 1 до 3 знаков>,<число от 1 до 3 знаков>,<число от 1 до 2 знаков>
            //все числа сохраняются в переменные (скобки вокруг \d{1,3})
            //так же регулярка считается выполненной если строка имеет одну из форм: <111>;  <111>,<111>;  <111>,<111>,<111>;  <111>,<111>,<111>,<11>
            //если какая то часть отсутствует а мы ниже попробуем обратиться к ней в массиве то там будет пустая строка. Поэтому чекаем на пустую строку и заменяем ее на 0

            const string regexMask = @"^<(-?\d{1,3})(?:>,<(-?\d{1,3})>(?:,<(-?\d{1,3})>(?:,<(\d{1,2})>)?)?)?$";
            int lineCount = 1;

            foreach (string instructionString in Regex.Split(programText.ToString()!, @"\s+"))
            {
                if (string.IsNullOrWhiteSpace(instructionString)) continue;
                Match match = Regex.Match(instructionString, regexMask);
                if (match.Success)
                {
                    var instruction = new Instruction();

                    instruction.Operand1 = match.Groups[1].Value == string.Empty ? 0 : int.Parse(match.Groups[1].Value);
                    instruction.Operand2 = match.Groups[2].Value == string.Empty ? 0 : int.Parse(match.Groups[2].Value);
                    instruction.Operand3 = match.Groups[3].Value == string.Empty ? 0 : int.Parse(match.Groups[3].Value);
                    instruction.Operation = match.Groups[4].Value == string.Empty ? 0 : int.Parse(match.Groups[4].Value);
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
               /*
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
               */
                return [DependencyProperty.UnsetValue];
            }

            return [instructions];
        }
    }
}
