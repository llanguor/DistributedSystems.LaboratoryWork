using Accessibility;
using DistributedSystems.LaboratoryWork.Nuget.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Types
{
    public class CompilerEnvironmentTypes
    {
        //все тут должно быть ассинхронным.
        //нужно внедрить логгер чтобы выводить что-либо на консоль.
    
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

        public static class Operations
        {
            #region Fields

            static List<Lazy<ICommand>> _operationsList;

            #endregion


            #region Constructors

            static Operations()
            {
                _operationsList = new List<Lazy<ICommand>>()
                {

                };
            }

            #endregion


            #region Properties

            public static List<Lazy<ICommand>> OperationsList
            {
                get => _operationsList;
            }

            #endregion


            #region Methods

            static void MethodId0()
            {

            }

            static void MethodId1()
            {

            }

            static void MethodId2()
            {

            }

            static void MethodId3()
            {

            }

            static void MethodId4()
            {

            }

            static void MethodId5()
            {

            }

            static void MethodId6()
            {

            }

            static void MethodId7()
            {

            }

            static void MethodId8()
            {

            }

            static void MethodId9()
            {

            }

            static void MethodId10()
            {

            }

            static void MethodId11()
            {

            }

            static void MethodId12()
            {

            }

            static void MethodId13()
            {

            }

            static void MethodId14()
            {

            }

            static void MethodId15()
            {

            }

            static void MethodId16()
            {

            }

            static void MethodId17()
            {

            }

            static void MethodId18()
            {

            }

            static void MethodId19()
            {

            }

            static void MethodId20()
            {

            }

            static void MethodId21()
            {

            }

            static void MethodId22()
            {

            }

            static void MethodId23()
            {

            }

            static void MethodId24()
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
