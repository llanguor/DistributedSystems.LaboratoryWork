using Accessibility;
using DistributedSystems.LaboratoryWork.Nuget.Command;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Types
{
    public class CompilerEnvironmentTypes
    {
        //все тут должно быть ассинхронным.
        //нужно внедрить логгер чтобы выводить что-либо на консоль.
    
        //TODO: check public classes fields

        internal class Registers
        {
            #region Fields

            private delegate void MethodDelegate(int operand1Key, int operand2Key, int operand3Key);

            private static List<Lazy<MethodDelegate>>? _operationsList;

            private Dictionary<int, object?> _registers;

            #endregion


            #region Properties

            public object? this[int key]
            {
                get
                {
                    return _registers[key];
                }
            }

            #endregion


            #region Constructors

            public Registers()
            {
                _registers = new Dictionary<int, object?>();

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

            public object? FromIndex(int key)
            {
                return _registers[key];
            }

            public void ExecuteMethod(int operand1Key, int operand2Key, int operand3Key, int operationId)
            {
                if (!_registers.ContainsKey(operand1Key))
                    _registers.Add(operand1Key, null);
                if (!_registers.ContainsKey(operand2Key))
                    _registers.Add(operand2Key, null);
                if (!_registers.ContainsKey(operand3Key))
                    _registers.Add(operand3Key, null);

                var operationMethod = _operationsList![operationId].Value;
                operationMethod(operand1Key, operand2Key, operand3Key);
            }

            private void ThrowIfIncorrectParameter(int operand1Key, int operand2Key, int operand3Key)
            {
                
            }

            #endregion


            #region Methods for registers

            private void MethodId0(int operand1Key, int operand2Key, int operand3Key)
            {
                _registers[operand1Key] = 7;
                //MessageBox.Show(_registers[operand1Key]!.ToString());
            }

            private void MethodId1(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId2(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId3(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId4(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId5(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId6(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId7(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId8(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId9(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId10(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId11(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId12(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId13(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId14(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId15(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId16(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId17(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId18(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId19(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId20(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId21(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId22(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId23(int operand1Key, int operand2Key, int operand3Key)
            {

            }

            private void MethodId24(int operand1Key, int operand2Key, int operand3Key)
            {

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
