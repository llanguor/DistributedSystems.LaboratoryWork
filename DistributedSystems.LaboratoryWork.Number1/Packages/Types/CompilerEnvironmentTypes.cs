using DistributedSystems.LaboratoryWork.Nuget.Command;
using System;
using System.Collections.Generic;
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

        public static class Operations
        {
            #region Properties

            public static List<Lazy<ICommand>> GetOperationsList
            {
                get
                {
                    return new List<Lazy<ICommand>>()
                    {

                    };
                }
            }
      
            #endregion

            #region Methods

            public static void MethodId0()
            {

            }

            public static void MethodId1()
            {

            }

            public static void MethodId2()
            {

            }

            public static void MethodId3()
            {

            }

            public static void MethodId4()
            {

            }

            public static void MethodId5()
            {

            }

            public static void MethodId6()
            {

            }

            public static void MethodId7()
            {

            }

            public static void MethodId8()
            {

            }

            public static void MethodId9()
            {

            }

            public static void MethodId10()
            {

            }

            public static void MethodId11()
            {

            }

            public static void MethodId12()
            {

            }

            public static void MethodId13()
            {

            }

            public static void MethodId14()
            {

            }

            public static void MethodId15()
            {

            }

            public static void MethodId16()
            {

            }

            public static void MethodId17()
            {

            }

            public static void MethodId18()
            {

            }

            public static void MethodId19()
            {

            }

            public static void MethodId20()
            {

            }

            public static void MethodId21()
            {

            }

            public static void MethodId22()
            {

            }

            public static void MethodId23()
            {

            }

            public static void MethodId24()
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
