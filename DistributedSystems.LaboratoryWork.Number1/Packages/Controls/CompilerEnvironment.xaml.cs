using DistributedSystems.LaboratoryWork.Nuget.Command;
using DistributedSystems.LaboratoryWork.Nuget.Dialog;
using DistributedSystems.LaboratoryWork.Number1.Packages.Types;
using DistributedSystems.LaboratoryWork.Number1.Utils.Numbers;
using DistributedSystems.LaboratoryWork.Number1.View.Dialogs;
using DistributedSystems.LaboratoryWork.Number1.View.Windows;
using DistributedSystems.LaboratoryWork.Number1.ViewModel.Dialogs;
using DryIoc;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static DistributedSystems.LaboratoryWork.Number1.Packages.Types.CompilerEnvironmentTypes;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Controls
{
    public partial class CompilerEnvironment : UserControl
    {

        #region Constructors

        public CompilerEnvironment()
        {
            InitializeComponent();

            Instructions = new ObservableCollection<Instruction>();
            _openFileCommand = new Lazy<ICommand>(() => new RelayCommand(_ => OpenFileCommandExecute()));
            _compileCommand = new Lazy<ICommand>(() => new RelayCommand(_ => CompileCommandExecute()));
        }

        #endregion


        #region Commands

        private readonly Lazy<ICommand> _compileCommand;

        public ICommand CompileCommand
            => _compileCommand.Value;

        private readonly Lazy<ICommand> _openFileCommand;

        public ICommand OpenFileCommand
           => _openFileCommand.Value;

        #endregion


        #region Properties

        public ObservableCollection<Instruction> Instructions
        {
            get => (ObservableCollection<Instruction>)GetValue(InstructionsProperty);
            set => SetValue(InstructionsProperty, value);
        }

        #endregion


        #region DependencyProperties

        public static readonly DependencyProperty InstructionsProperty = DependencyProperty.Register(
            nameof(Instructions),
            typeof(ObservableCollection<Instruction>),
            typeof(CompilerEnvironment));

        #endregion


        #region Methods

        private void OpenFileCommandExecute()
        {
            var openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == false)
                return;

            string fileText = System.IO.File.ReadAllText(openFileDialog1.FileName);
            programTextBox.Text = fileText;

            programTextBox.Focus();
            programDataGrid.Focus();
        }

        private void CompileCommandExecute()
        {
            /*
            if (_dialogAware.ShowDialog(DialogAwareParameters.Builder.Create()
            .ForDialogType<SpinnerDialogViewModel>()
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerItemsCount, 2)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerRadiusCoefficient, 0.2)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerColor, Brushes.LightGray)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerRotationDirection, Spinner.RotationDirection.Counterclockwise)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerSpeed, new TimeSpan(1000))
            .AddParameter(SpinnerDialogViewModel.Parameters.Text, "Please wait...")
            .AddParameter(SpinnerDialogViewModel.Parameters.FontSize, 30)
            .Build()))
            {
                System.Windows.MessageBox.Show("Dialog result: ACCEPTED");
            }
            else
            {
                System.Windows.MessageBox.Show("Dialog result: CANCELLED");
            }
            */

            
            //все это должно быть ассинхронным


            /*
            //процесс компиляции
            using var memoryStream = new MemoryStream(new byte[255]);

            using var binaryWriter = new BinaryWriter(memoryStream);
            foreach (var instruction in Instructions)
            {
                var instructionValue = NumberToBytesTransformations.ConvertToBytes(
                    instruction.Operand1,
                    instruction.Operand2,
                    instruction.Operand3,
                    instruction.Operation);

                binaryWriter.Write(instructionValue);
            }



            //процесс исполнения
           

            using var binaryReader = new BinaryReader(memoryStream);
            long? readNumber;
            int operand1Key, operand2Key, operand3Key, operationId;

            memoryStream.Position = 0;
            Registers registers = new Registers();
            registers[0] = 10;


            while ((readNumber = binaryReader.ReadInt64()) != null)
            {
                if (readNumber == 0) break;

                NumberToBytesTransformations.ConvertToValues(
                    readNumber.Value,
                    out operand1Key,
                    out operand2Key,
                    out operand3Key,
                    out operationId);

                registers.ExecuteMethod(operand1Key, operand2Key, operand3Key, operationId);


            }
            */
        }
        
        //TODO: потом исполнение переедет в Dialog. Внутри сделать клаву как я уже делал ранее. И консоль
        //то есть совместить два моих окна. Ввод с клавы когда этого запросит прога. Если нет ввода то затемнять?
        //вот так будет делаться ввод

        #endregion
    }
}
