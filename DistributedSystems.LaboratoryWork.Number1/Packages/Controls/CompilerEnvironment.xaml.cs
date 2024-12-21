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
            _launchCommand = new Lazy<ICommand>(() => new RelayCommand(_ => LaunchCommandExecute()));
            _dialogAware = App.Container.Resolve<IDialogAware>();
        }

        #endregion


        #region Commands

        private readonly Lazy<ICommand> _launchCommand;

        public ICommand LaunchCommand
            => _launchCommand.Value;

        private readonly Lazy<ICommand> _openFileCommand;

        public ICommand OpenFileCommand
           => _openFileCommand.Value;

        #endregion


        #region Fields

        private readonly IDialogAware _dialogAware;

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

        private async void OpenFileCommandExecute()
        {
            //TODO: посмотреть в каких случаях получается неотлавливаемая ошибка. Можно ли тут использовать лямбду,
            //TODO: ИМЕННО ЭТОТ СЛУЧАЙ. ИСПРАВЛЯТЬ ВЕЗДЕ ЛЯМБЛЫ. ХЗ НА ЧТО

            Task<string> openFileTask = Task<string>.Run(() =>
            {
                var openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == false)
                    return "";

                string data = System.IO.File.ReadAllText(openFileDialog1.FileName); 

                var dialogViewModel = App.Container.Resolve<SpinnerDialogViewModel>();
                dialogViewModel.Text = "File searched";
                dialogViewModel.LoadingAnimationActive = false;

                return data;
            });

            _dialogAware.ShowDialog(DialogAwareParameters.Builder.Create()
                .ForDialogType<SpinnerDialogViewModel>()
                .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerItemsCount, 2)
                .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerRadiusCoefficient, 0.2)
                .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerColor, Brushes.LightGray)
                .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerRotationDirection, Spinner.RotationDirection.Counterclockwise)
                .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerSpeed, new TimeSpan(1000))
                .AddParameter(SpinnerDialogViewModel.Parameters.Text, "Searching for file")
                .AddParameter(SpinnerDialogViewModel.Parameters.FontSize, 30)
                .Build());

            await openFileTask;
            programTextBox.Text = openFileTask.Result;
            programTextBox.Focus();
            programDataGrid.Focus();

        }

        private async void LaunchCommandExecute()
        {
            Task launchExecuteTask = LaunchExecute();

            if (_dialogAware.ShowDialog(DialogAwareParameters.Builder.Create()
            .ForDialogType<SpinnerDialogViewModel>()
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerItemsCount, 2)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerRadiusCoefficient, 0.2)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerColor, Brushes.LightGray)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerRotationDirection, Spinner.RotationDirection.Counterclockwise)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerSpeed, new TimeSpan(1000))
            .AddParameter(SpinnerDialogViewModel.Parameters.Text, "Building")
            .AddParameter(SpinnerDialogViewModel.Parameters.FontSize, 30)
            .Build()))
            {
                //TODO
            }
            else
            {

            }


            await launchExecuteTask;
        }

        async Task LaunchExecute()
        {
            var dialogViewModel = App.Container.Resolve<SpinnerDialogViewModel>();
            await Task.Delay(800);

            dialogViewModel.Text = "Compiling";
            var byteArray = await CompileExecute(Instructions);
            await Task.Delay(800);

            dialogViewModel.Text = "Executing";
            Task performanceTask = PerformanceExecute(byteArray);

            var dialog = App.Container.Resolve<CompilerEnvironmentDialog>();
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dialog.ShowDialog();

            await Task.Delay(800);
            await performanceTask;
            
            dialogViewModel.LoadingAnimationActive = false;
            dialogViewModel.Text = "Executed";
        }


        async Task<byte[]> CompileExecute(ObservableCollection<Instruction> instructions)
        {
            return await Task.Run(() =>
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
            });
        }

        async Task PerformanceExecute(byte[] memoryStreamArray)
        {
            await Task.Run(() =>
            {
                long? readNumber;
                int operand1Key, operand2Key, operand3Key, operationId;

                using var memoryStream = new MemoryStream(memoryStreamArray);
                memoryStream.Position = 0;

                Registers registers = new Registers();
                registers[1] = 10;

                using var binaryReader = new BinaryReader(memoryStream);

                while ((readNumber = binaryReader.ReadInt64()) != 0)
                {
                    NumberToBytesTransformations.ConvertToValues(
                        readNumber.Value,
                        out operand1Key,
                        out operand2Key,
                        out operand3Key,
                        out operationId);

                    registers.ExecuteMethod(operand1Key, operand2Key, operand3Key, operationId);
                   
                    //в класс регистров подвавать ICommand для того метода клавиатуры
                }
            });
        }

        #endregion
    }
}
