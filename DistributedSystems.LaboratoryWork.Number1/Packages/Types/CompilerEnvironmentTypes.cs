using Accessibility;
using DistributedSystems.LaboratoryWork.Nuget.Command;
using DistributedSystems.LaboratoryWork.Number1.Utils.Logger;
using DistributedSystems.LaboratoryWork.Number1.Utils.Numbers;
using DryIoc;
using Microsoft.Extensions.Logging;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using static DistributedSystems.LaboratoryWork.Number1.Packages.Types.CompilerEnvironmentTypes;


namespace DistributedSystems.LaboratoryWork.Number1.Packages.Types
{
    public class CompilerEnvironmentTypes
    {
        //TODO: check public classes fields

        internal class Registers
        {
            #region Fields

            private delegate void MethodDelegate(int operand1Key, int operand2Key, int operand3Key);

            private static List<Lazy<MethodDelegate>>? _operationsList;

            private SortedDictionary<int, int> _registers;

            private Logger _logger;

            private Lazy<ICommand> _requestToInputCommand;

            private Lazy<ICommand> _logCommand;

            #endregion


            #region Properties

            public int this[int key]
            {
                get => _registers[key];
                set => _registers[key] = value;
            }


            #endregion


            #region Constructors

            public Registers(ICommand requestToInputCommand, ICommand logCommand)
            {
                _registers = [];

                _requestToInputCommand = new Lazy<ICommand>(requestToInputCommand);

                _logCommand = new Lazy<ICommand>(logCommand);

                _logger = App.Container.Resolve<Logger>();

                _operationsList =
                [
                    new Lazy<MethodDelegate>(MethodId0),
                    new Lazy<MethodDelegate>(MethodId1),
                    new Lazy<MethodDelegate>(MethodId2),
                    new Lazy<MethodDelegate>(MethodId3),
                    new Lazy<MethodDelegate>(MethodId4),
                    new Lazy<MethodDelegate>(MethodId5),
                    new Lazy<MethodDelegate>(MethodId6),
                    new Lazy<MethodDelegate>(MethodId7),
                    new Lazy<MethodDelegate>(MethodId8),
                    new Lazy<MethodDelegate>(MethodId9),
                    new Lazy<MethodDelegate>(MethodId10),
                    new Lazy<MethodDelegate>(MethodId11),
                    new Lazy<MethodDelegate>(MethodId12),
                    new Lazy<MethodDelegate>(MethodId13),
                    new Lazy<MethodDelegate>(MethodId14),
                    new Lazy<MethodDelegate>(MethodId15),
                    new Lazy<MethodDelegate>(MethodId16),
                    new Lazy<MethodDelegate>(MethodId17),
                    new Lazy<MethodDelegate>(MethodId18),
                    new Lazy<MethodDelegate>(MethodId19),
                    new Lazy<MethodDelegate>(MethodId20),
                    new Lazy<MethodDelegate>(MethodId21),
                    new Lazy<MethodDelegate>(MethodId22),
                    new Lazy<MethodDelegate>(MethodId23),
                    new Lazy<MethodDelegate>(MethodId24)
                ];
            }

            #endregion


            #region Methods

            public void Log(string text)
            {
                _logCommand.Value.Execute(text);
            }

            public object? FromIndex(int key)
            {
                return _registers[key];
            }

            public void ExecuteMethod(int operand1Key, int operand2Key, int operand3Key, int operationId)
            {
                if (operand1Key > 511 || operand1Key < 0)
                    throw new ArgumentOutOfRangeException(nameof(operand1Key));
                if (operand2Key > 511 || operand2Key < 0)
                    throw new ArgumentOutOfRangeException(nameof(operand2Key));
                if (operand3Key > 511 || operand3Key < 0)
                    throw new ArgumentOutOfRangeException(nameof(operand3Key));
                if (operationId > 24 || operationId < 0)
                    throw new ArgumentOutOfRangeException(nameof(operationId));

                if (!_registers.ContainsKey(operand1Key))
                    _registers.Add(operand1Key, default);
                if (!_registers.ContainsKey(operand2Key))
                    _registers.Add(operand2Key, default);
                if (!_registers.ContainsKey(operand3Key))
                    _registers.Add(operand3Key, default);

                var operationMethod = _operationsList![operationId].Value;

                _logger.Log($"Method {operationId} is being executed");
                operationMethod(operand1Key, operand2Key, operand3Key);
                _logger.Log($"Method {operationId} has finished executing.");
            }

            #endregion


            #region Methods for registers

            //TODO: Exceptions

            private void MethodId0(int operand1Key, int operand2Key, int operand3Key)
            {
                int numberSystem = Convert.ToInt32(_registers[operand1Key]);
                _logger.Log($"Register's values in {numberSystem} number system");

                foreach (KeyValuePair<int, int> pair in _registers)
                {
                    int value = Convert.ToInt32(pair.Value);
                    string result = NumberSystemTransformations.ConvertNumberToBase(value, numberSystem);

                    _logger.Log($"{pair.Key}: {result}");
                }
            }

            private void MethodId1(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] = ~_registers[operand1Key];
            }

            private void MethodId2(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] = _registers[operand1Key] | _registers[operand2Key];
            }

            private void MethodId3(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] = _registers[operand1Key] & _registers[operand2Key];
            }

            private void MethodId4(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] = _registers[operand1Key] ^ _registers[operand2Key];
            }

            private void MethodId5(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] = ~_registers[operand1Key] | _registers[operand2Key];
            }

            private void MethodId6(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] = ~(~_registers[operand1Key] | _registers[operand2Key]);
            }

            private void MethodId7(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] =
                    (~_registers[operand1Key] & ~_registers[operand2Key]) |
                    (_registers[operand1Key] & _registers[operand2Key]);
            }

            private void MethodId8(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] = ~(_registers[operand1Key] | _registers[operand2Key]);
            }

            private void MethodId9(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] = ~(_registers[operand1Key] & _registers[operand2Key]);
            }

            private void MethodId10(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] = _registers[operand1Key] + _registers[operand2Key];
            }

            private void MethodId11(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] = _registers[operand1Key] - _registers[operand2Key];
            }

            private void MethodId12(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] = _registers[operand1Key] * _registers[operand2Key];
            }

            private void MethodId13(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] = _registers[operand1Key] / _registers[operand2Key];
            }

            private void MethodId14(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] = _registers[operand1Key] % _registers[operand2Key];
            }

            private void MethodId15(int operand1Key, int operand2Key, int operand3Key)
            {
                (_registers[operand1Key], _registers[operand2Key]) = (_registers[operand2Key], _registers[operand1Key]);
            }

            private void MethodId16(int operand1Key, int operand2Key, int operand3Key)
            {
                //255 - маска для выделения одного байта
                //byteNumber*8 - сдвиг на нужное количество байтов

                int byteIndex = _registers[operand2Key];
                if (byteIndex < 0 || byteIndex > 3) throw new ArgumentException("In a 32 bit number there are only 4 bytes");

                int byteValue = (_registers[operand3Key] >> byteIndex * 8) & 255;  // Извлечение третьего байта
                _registers[operand1Key] &= ~(255 << byteIndex * 8);                // Маска для обнуления байта
                _registers[operand1Key] |= (byteValue << byteIndex * 8);           // Запись байта на нужное место
            }

            private void MethodId17(int operand1Key, int operand2Key, int operand3Key)
            {
                int numberSystem = Convert.ToInt32(_registers[operand2Key]);
                int value = Convert.ToInt32(_registers[operand1Key]);
                string result = NumberSystemTransformations.ConvertNumberToBase(value, numberSystem);

                _logger.Log($"Value in operand {operand1Key} in {numberSystem} number system: {result}");

            }

            private void MethodId18(int operand1Key, int operand2Key, int operand3Key)
            {
                _logger.Log($"Please enter value for register with number {operand1Key}");
                _requestToInputCommand.Value.Execute(null);
            }

            private void MethodId19(int operand1Key, int operand2Key, int operand3Key)
            {
                int value = _registers[operand1Key];
                int degree = 0;

                while ((value & 1) == 0) //Двигаем число вправо пока младший бит = 0
                {
                    degree++;
                    value >>= 1;
                }

                _registers[operand3Key] = 1 << degree; // 2^p
            }

            private void MethodId20(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] = _registers[operand1Key] << _registers[operand2Key];
            }

            private void MethodId21(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand3Key] = _registers[operand1Key] >> _registers[operand2Key];
            }

            private void MethodId22(int operand1Key, int operand2Key, int operand3Key)
            {
                int value = _registers[operand1Key];
                int shift = _registers[operand2Key];
                shift %= 32; // чтобы не было избыточного сдвига (для 32 битных чисел)
                _registers[operand3Key] = (value << shift) | (value >> (32 - shift));

            }

            private void MethodId23(int operand1Key, int operand2Key, int operand3Key)
            {
                int value = _registers[operand1Key];
                int shift = _registers[operand2Key];
                shift %= 32; // чтобы не было избыточного сдвига (для 32 битных чисел)
                _registers[operand3Key] = (value >> shift) | (value << (32 - shift));
            }

            private void MethodId24(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand1Key] = _registers[operand2Key];
            }

            #endregion
        }

        public class Instruction : INotifyPropertyChanged
        {
            #region Fields

            private int _operand1;
            private int _operand2;
            private int _operand3;
            private int _operation;

            #endregion

            #region Constructors

            public Instruction(int operand1, int operand2, int operand3, int operation)
            {
                Operand1 = operand1;
                Operand2 = operand2;
                Operand3 = operand3;
                Operation = operation;
            }

            public Instruction()
            {

            }

            #endregion

            #region Properties

            public int Operand1
            {
                get => _operand1;
                set
                {
                    _operand1 = value;
                    OnPropertyChanged(nameof(Operand1));
                }
            }
            public int Operand2
            {
                get => _operand2;
                set
                {
                    _operand2 = value;
                    OnPropertyChanged(nameof(Operand2));
                }
            }
            public int Operand3
            {
                get => _operand3;
                set
                {
                    _operand3 = value;
                    OnPropertyChanged(nameof(Operand3));
                }
            }

            public int Operation
            {
                get => _operation;
                set
                {
                    _operation = value;
                    OnPropertyChanged(nameof(Operation));
                }
            }

            #endregion

            #region INotifyPropertyChanged Implementation

            public event PropertyChangedEventHandler? PropertyChanged;
            public void OnPropertyChanged([CallerMemberName] string prop = "")
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }

            #endregion
        }

        internal class ExecutionManager : IDisposable
        {
            #region Fields

            private long? _readNumber = null;

            private int _operand1Key, _operand2Key, _operand3Key, _operationId;


            private bool _disposed = false;

            Registers _registers;

            MemoryStream _memoryStream;

            BinaryReader _binaryReader;

            private bool _executionComplete = false;

            #endregion


            #region Properties

            public bool ExecutionComplete
                => _executionComplete;

            #endregion


            #region Methods

            public ExecutionManager(byte[] memoryStreamArray, ICommand requestToInputCommand, ICommand logCommand)
            {
                _registers = new Registers(requestToInputCommand, logCommand);
                _memoryStream = new MemoryStream(memoryStreamArray);
                _memoryStream.Position = 0;
                _binaryReader = new BinaryReader(_memoryStream);
            }

            public async Task StartExecutionFlowAsync()
            {
                await Task.Run(() =>
               {
                   StartExecutionFlow();
               });
            }

            public async Task ContinueExecutionFlowAsync(int inputValue)
            {
                await Task.Run(() =>
                {
                    ContinueExecutionFlow(inputValue);
                });
            }


            public void StartExecutionFlow()
            {
                if (_readNumber != null)
                {
                    throw new InvalidOperationException("Execution had already started earlier");
                }

                ExecutionFlow();
            }

            public void ContinueExecutionFlow(int inputValue)
            {
                if (_readNumber is null)
                {
                    throw new InvalidOperationException("Execution has not yet begun");
                }

                _registers[_operand1Key] = inputValue;

                ExecutionFlow();
            }

            private void ExecutionFlow()
            {
                while ((_readNumber = _binaryReader.ReadInt64()) != 0)
                {
                    NumberToBytesTransformations.ConvertToValues(
                        _readNumber.Value,
                        out _operand1Key,
                        out _operand2Key,
                        out _operand3Key,
                        out _operationId);

                    _registers.ExecuteMethod(_operand1Key, _operand2Key, _operand3Key, _operationId);

                    if (_operationId == 18)
                        return;
                }

                _executionComplete = true;
            }

            #endregion


            #region Dispose

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (_disposed) return;
                if (disposing)
                {

                }

                _binaryReader.Dispose();
                _disposed = true;
            }

            ~ExecutionManager()
            {
                Dispose(false);
            }

            #endregion
        }

        internal static class CompilerManager
        {
            public static byte[] Compile(IEnumerable<Instruction> instructions)
            {
                using var memoryStream = new MemoryStream(new byte[255]);
                using var binaryWriter = new BinaryWriter(memoryStream);

                foreach (var instruction in instructions)
                {
                    var instructionValue = NumberToBytesTransformations.ConvertToBytes(
                        instruction.Operand1,
                        instruction.Operand2,
                        instruction.Operand3,
                        instruction.Operation);

                    binaryWriter.Write(instructionValue);
                }

                return memoryStream.ToArray();
            }

            public static async Task<byte[]> CompileAsync(IEnumerable<Instruction> instructions)
            {
                return await Task.Run(() =>
                {
                    return Compile(instructions);
                });
            }

        }
    }
}




/*
public static class CodeCompiler
{
    public static string Compile(List<Instruction> instructions)
    {
        return "";
    }
}

public class CodePerformer
{
    #region Fields

    List<int> _registersList;

    #endregion


    #region Constructors

    public CodePerformer()
    {
        _registersList = new List<int>();
    }

    #endregion


    #region Properties

    public List<int> RegistersList
    {
        get => _registersList;
    }

    #endregion


    #region Methods

    public void Perform(Collection<int> instructions)
    {
        foreach(var instruction in instructions)
        {

        }
    }

    #endregion
}
*/
