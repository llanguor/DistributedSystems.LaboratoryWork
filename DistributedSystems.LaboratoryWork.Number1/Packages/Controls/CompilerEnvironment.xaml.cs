using DistributedSystems.LaboratoryWork.Nuget.Command;
using DistributedSystems.LaboratoryWork.Nuget.Dialog;
using DistributedSystems.LaboratoryWork.Number1.Packages.Converters;
using DistributedSystems.LaboratoryWork.Number1.Packages.Types;
using DistributedSystems.LaboratoryWork.Number1.Utils.Numbers;
using DistributedSystems.LaboratoryWork.Number1.ViewModel.Dialogs;
using DryIoc;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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
            _inputFromDialogCommand = new Lazy<ICommand>(() => new AsyncRelayCommand((value)=>InputFromDialogCommandExecute(value!.ToString())));
            _openFileCommand = new Lazy<ICommand>(() => new AsyncRelayCommand(OpenFileCommandExecute));
            _launchCommand = new Lazy<ICommand>(() => new AsyncRelayCommand(_=>LaunchCommandExecute()));
            _dialogAware = App.Container.Resolve<IDialogAware>();
        }

        #endregion

        //TODO: универсализировать все структуры регионов

        #region Commands


        private readonly Lazy<ICommand> _launchCommand;

        public ICommand LaunchCommand
            => _launchCommand.Value;

        private readonly Lazy<ICommand> _openFileCommand;

        public ICommand OpenFileCommand
           => _openFileCommand.Value;


        private readonly Lazy<ICommand> _inputFromDialogCommand;

        public ICommand InputFromDialogCommand
            => _inputFromDialogCommand.Value;

        #endregion


        #region Fields

        private readonly IDialogAware _dialogAware;

        ExecutionManager? _executionManager;

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


        private async Task OpenFileCommandExecute(object? obj)
        {
            var dialogViewModel = App.Container.Resolve<SpinnerDialogViewModel>();
            var openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == false)
                return;

            Task<string> openFileTask = Task.Run(async () =>
            {
                await Task.Delay(1000);
                string data = System.IO.File.ReadAllText(openFileDialog1.FileName); 
                dialogViewModel.Text = "File loaded";
                return data;
            });

            var dialog = _dialogAware.ShowDialogAsync(DialogAwareParameters.Builder.Create()
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

            var res = new CompilerEnvironmentConverter().ConvertBack(openFileTask.Result, Array.Empty<Type>(), null, CultureInfo.CurrentCulture);
            Instructions = (ObservableCollection<Instruction>)res[0];

            await LaunchExecute();

            await dialog;
            if (dialog.Result)
            {
                //TODO
            }
            else
            { 

            }

        }

        private async Task LaunchCommandExecute()
        {
            Task launchExecuteTask = LaunchExecute();

            var dialogTask = _dialogAware.ShowDialogAsync(DialogAwareParameters.Builder.Create()
            .ForDialogType<SpinnerDialogViewModel>()
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerItemsCount, 2)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerRadiusCoefficient, 0.2)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerColor, Brushes.LightGray)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerRotationDirection, Spinner.RotationDirection.Counterclockwise)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerSpeed, new TimeSpan(1000))
            .AddParameter(SpinnerDialogViewModel.Parameters.Text, "Building")
            .AddParameter(SpinnerDialogViewModel.Parameters.FontSize, 30)
            .Build());
           
            await launchExecuteTask;
            await dialogTask;

            if (dialogTask.Result)
            {

            }
            else
            {

            }
        }

        async Task LaunchExecute()
        {
            var dialogViewModel = App.Container.Resolve<SpinnerDialogViewModel>();
            await Task.Delay(1000);

            dialogViewModel.Text = "Compiling";
            var byteArray = await CompileExecute(Instructions);
            await Task.Delay(1000);


            
           
            App.Container.Unregister<CompilerEnvironmentDialogViewModel>();
            App.Container.Register<CompilerEnvironmentDialogViewModel>(Reuse.Singleton);
            dialogViewModel.Text = "Executing";
            await Task.Delay(1000);

            Task performanceTask = PerformanceExecute(byteArray);

            if (_dialogAware.ShowDialog(DialogAwareParameters.Builder.Create()
             .ForDialogType<CompilerEnvironmentDialogViewModel>()
             .AddParameter(CompilerEnvironmentDialogViewModel.Parameters.ButtonEnterCommand, InputFromDialogCommand)
             .Build()))
            {
                //TODO
            }
            else
            {

            }
         
            await performanceTask;
            dialogViewModel.LoadingAnimationActive = false;
            dialogViewModel.Text = "Executed";
        }


        async Task<byte[]> CompileExecute(ObservableCollection<Instruction> instructions)
        {
            return await CompilerManager.CompileAsync(instructions);
        }

        async Task PerformanceExecute(byte[] memoryStreamArray)
        {
            _executionManager?.Dispose();
            _executionManager = 
                new ExecutionManager(
                    memoryStreamArray, 
                    new RelayCommand(_ => RequestToInputFromDialogCommandExecute()),
                    new RelayCommand((text) => LogCommandExecute(text!.ToString()!))
                    );

            var dialogViewModel = App.Container.Resolve<CompilerEnvironmentDialogViewModel>();
            try
            {
                await _executionManager.StartExecutionFlowAsync();
            }
            catch
            {
                dialogViewModel.ExecutionComplete = true;
                throw;
            }
            finally
            {
                if (_executionManager.ExecutionComplete)
                    dialogViewModel.ExecutionComplete = true;
            }
        }

        private async Task InputFromDialogCommandExecute(object? inputValue)
        {
            //throw new ArgumentException();
            if (_executionManager is null)
                throw new InvalidOperationException(
                    "This operation can be execute only from CompilerEnvironmentDialog");

            if (_executionManager.ExecutionComplete)
                throw new InvalidOperationException(
                    "Execution already completed");

            if (inputValue is null)
                throw new ArgumentException("Incorrect parameter");


            if (!int.TryParse(inputValue!.ToString(), out var value))
            {
                throw new ArgumentException("Parameter must be int value");
            }

            var dialogViewModel = App.Container.Resolve<CompilerEnvironmentDialogViewModel>();
            try
            {
               await _executionManager.ContinueExecutionFlowAsync(value);
            }
            catch
            {
                dialogViewModel.ExecutionComplete = true;
                //MessageBox.Show("asd");
                throw;
            }
           
            finally
            {
                if (_executionManager.ExecutionComplete)
                    dialogViewModel.ExecutionComplete = true;
            }


        }

        private void RequestToInputFromDialogCommandExecute()
        {
            App.Container.Resolve<CompilerEnvironmentDialogViewModel>()
                .InputExpected = true;
        }

        private void LogCommandExecute(string message)
        {
            App.Container.Resolve<CompilerEnvironmentDialogViewModel>().ConsoleOut += $"\r\n{message}";
        }

        #endregion
    }
}
