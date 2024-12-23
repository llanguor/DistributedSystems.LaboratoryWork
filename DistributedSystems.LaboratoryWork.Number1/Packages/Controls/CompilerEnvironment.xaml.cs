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
    public partial class CompilerEnvironment : UserControl, IDisposable
    {

        #region Constructors

        public CompilerEnvironment()
        {
            InitializeComponent();
            
            Instructions = new ObservableCollection<Instruction>();
            _openFileCommand = new Lazy<ICommand>(() => new AsyncRelayCommand(OpenFileCommandExecute));
            _launchCommand = new Lazy<ICommand>(() => new AsyncRelayCommand(_=>LaunchCommandExecute()));
            _dialogAware = App.Container.Resolve<IDialogAware>();
        }

        #endregion

        #region Fields

        private readonly IDialogAware _dialogAware;

        private ExecutionManager? _executionManager;

        private readonly Lazy<ICommand> _launchCommand;

        private readonly Lazy<ICommand> _openFileCommand;

        bool _disposed = false;

        #endregion

        #region Properties

        public ObservableCollection<Instruction> Instructions
        {
            get => (ObservableCollection<Instruction>)GetValue(InstructionsProperty);
            set => SetValue(InstructionsProperty, value);
        }

        public ICommand LaunchCommand
            => _launchCommand.Value;

        public ICommand OpenFileCommand
            => _openFileCommand.Value;

        #endregion

        #region DependencyProperties

        public static readonly DependencyProperty InstructionsProperty = DependencyProperty.Register(
            nameof(Instructions),
            typeof(ObservableCollection<Instruction>),
            typeof(CompilerEnvironment));

        #endregion

        #region Methods for commands

        private async Task OpenFileCommandExecute(object? obj)
        {
            var dialogViewModel = App.Container.Resolve<SpinnerDialogViewModel>();

            

            Task<string?> openFileTask = Task.Run(() =>
            {
                var openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == false)
                    return null;

                string? data = null;
                try
                {
                    data = System.IO.File.ReadAllText(openFileDialog.FileName);
                    dialogViewModel.Text = "File loaded";
                }
                catch(Exception ex)
                {
                    ShowMessageDialogException(ex.Message);
                }
                
                return data;
            });

            var dialogTask = _dialogAware.ShowDialogAsync(DialogAwareParameters.Builder.Create()
                .ForDialogType<SpinnerDialogViewModel>()
                .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerItemsCount, 2)
                .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerRadiusCoefficient, 0.2)
                .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerColor, Brushes.LightGray)
                .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerRotationDirection, Spinner.RotationDirection.Counterclockwise)
                .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerSpeed, new TimeSpan(1000))
                .AddParameter(SpinnerDialogViewModel.Parameters.Text, "Searching for file")
                .AddParameter(SpinnerDialogViewModel.Parameters.FontSize, 30)
                .Build());

            if (await openFileTask is null) return;

            object outputInstructions;
            try
            {
                outputInstructions = new CompilerEnvironmentConverter()
                    .ConvertBack(
                        openFileTask.Result,
                        Array.Empty<Type>(),
                        null,
                        CultureInfo.CurrentCulture)[0];
            }
            catch(Exception ex)
            {
                ShowMessageDialogException($"File does not exist or is in an invalid format. {ex.Message}");
                return;
            }


            Instructions = (ObservableCollection<Instruction>)outputInstructions;

            //await LaunchExecute(); 
            await dialogTask;
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
        }

        #endregion

        #region Methods for execution

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

            _dialogAware.ShowDialog(DialogAwareParameters.Builder.Create()
             .ForDialogType<CompilerEnvironmentDialogViewModel>()
             .AddParameter(
                CompilerEnvironmentDialogViewModel.Parameters.ButtonEnterCommand,
                new AsyncRelayCommand((value) => InputFromDialogCommandExecute(value!.ToString())))
             .Build());
         
            await performanceTask;
            dialogViewModel.LoadingAnimationActive = false;
            dialogViewModel.Text = "Executed";
        }

        async Task<byte[]> CompileExecute(ObservableCollection<Instruction> instructions)
        {
            try
            {
                return await CompilerManager.CompileAsync(instructions);
            }
            catch (Exception ex)
            {
                ShowMessageDialogException(ex.Message);
            }

            return Array.Empty<byte>();
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
            catch (CompilerExceptions.CompilerException ex)
            {
                ShowMessageDialogException($"Error in method {ex.Value}: {ex.Message}");
                dialogViewModel.ExecutionComplete = true;
            }
            catch (Exception ex)
            {
                ShowMessageDialogException(ex.Message);
                dialogViewModel.ExecutionComplete = true;
            }
            finally
            {
                if (_executionManager.ExecutionComplete)
                    dialogViewModel.ExecutionComplete = true;
            }
        }
       
        private bool ShowMessageDialogException(string message)
        {

            var parameters = DialogAwareParameters.Builder.Create()
               .ForDialogType<MessageDialogViewModel>()
               .AddParameter(MessageDialogViewModel.Parameters.PositiveCommand, null)
               .AddParameter(MessageDialogViewModel.Parameters.NegativeCommand, null)
               .AddParameter(MessageDialogViewModel.Parameters.DialogHostCommand, null)
               .AddParameter(MessageDialogViewModel.Parameters.Text, message)
               .AddParameter(MessageDialogViewModel.Parameters.DialogTypeValue, MessageDialogTypes.DialogType.Ok)
               .AddParameter(MessageDialogViewModel.Parameters.ScrollViewerBackground, Colors.AliceBlue)
               .AddParameter(MessageDialogViewModel.Parameters.ScrollViewerHorizontalVisible, ScrollBarVisibility.Disabled)
               .AddParameter(MessageDialogViewModel.Parameters.ScrollViewerVerticalVisible, ScrollBarVisibility.Visible)
               .Build();

            return _dialogAware.ShowDialog(parameters);
        }

        #endregion

        #region Methods for injection

        private async Task InputFromDialogCommandExecute(object? inputValue)
        {
            var dialogViewModel = App.Container.Resolve<CompilerEnvironmentDialogViewModel>();

            try
            {
                if (_executionManager is null)
                    throw new InvalidOperationException(
                        "This operation can be execute only from CompilerEnvironmentDialog");

                if (_executionManager.ExecutionComplete)
                    throw new InvalidOperationException(
                        "Execution already completed");

                if (inputValue is null)
                    throw new ArgumentException("Incorrect parameter");

                if (!int.TryParse(inputValue!.ToString(), out var value))
                    throw new ArgumentException("Parameter must be int value");

                await _executionManager.ContinueExecutionFlowAsync(value);
                if (_executionManager.ExecutionComplete)
                    dialogViewModel.ExecutionComplete = true;
            }
            catch (CompilerExceptions.CompilerException ex)
            {
                ShowMessageDialogException($"Error in method {ex.Value}: {ex.Message}");
                dialogViewModel.ExecutionComplete = true;
            }
            catch(InvalidOperationException ex)
            {
                ShowMessageDialogException(ex.Message);
            }
            catch (ArgumentException ex)
            {
                ShowMessageDialogException(ex.Message);
            }
            catch (Exception ex)
            {
                ShowMessageDialogException(ex.Message);
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

            _executionManager?.Dispose();
            _disposed = true;
        }

        ~CompilerEnvironment()
        {
            Dispose(false);
        }

        #endregion

    }
}
