using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistributedSystems.LaboratoryWork.Nuget.Dialog;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DistributedSystems.LaboratoryWork.Nuget.ViewModel;
using DistributedSystems.LaboratoryWork.Number1.Packages.Types;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DistributedSystems.LaboratoryWork.Nuget.Command;
using System.Runtime.CompilerServices;
using System.Windows;
using System.ComponentModel;

namespace DistributedSystems.LaboratoryWork.Number1.ViewModel.Dialogs
{
    internal class CompilerEnvironmentDialogViewModel:
        DialogViewModelBase
    {

        #region Constructors

        public CompilerEnvironmentDialogViewModel() 
        {
            _buttonCommand = new Lazy<ICommand>(() => new RelayCommand((prop) => ButtonCommandExecute(prop!.ToString()!)));
            _buttonClearCommand = new Lazy<ICommand>(() => new RelayCommand(_ => ButtonClearCommandExecute()));
            _buttonEnterCommand = new Lazy<ICommand>(() => new AsyncRelayCommand(ButtonEnterCommandExecute));
            ConsoleOut = string.Empty;
            OutputText = string.Empty;
            InputExpected = false;
            ExecutionComplete = false;

        }

        #endregion

        #region Fields

        private bool _inputExpected;

        private bool _executionComplete;

        private string? _consoleOut;

        private string? _outputText;

        private readonly Lazy<ICommand> _buttonCommand;

        private readonly Lazy<ICommand> _buttonClearCommand;

        private readonly Lazy<ICommand>? _buttonEnterCommand;

        private Lazy<ICommand>? _externalButtonEnterCommand;

        

        #endregion


        #region Properties

        public bool InputExpected
        {
            get => _inputExpected;
            set
            {
                _inputExpected = value;
                RaisePropertyChanged(nameof(InputExpected));
            }
            
        }

        public bool ExecutionComplete
        {
            get => _executionComplete;
            set
            {
                _executionComplete = value;
                RaisePropertyChanged(nameof(ExecutionComplete));
            }

        }

        public string ConsoleOut
        {
            get => _consoleOut!;

            set
            {
                _consoleOut = value; 
                RaisePropertyChanged(nameof(ConsoleOut));
            }
        }

        public string OutputText
        {
            get => _outputText!;

            set
            {
                _outputText = value;
                RaisePropertyChanged(nameof(OutputText));
            }
        }

        public ICommand ButtonCommand =>
          _buttonCommand.Value;

        public ICommand ButtonClearCommand =>
            _buttonClearCommand.Value;

        public ICommand ButtonEnterCommand =>
            _buttonEnterCommand!.Value;

        public ICommand ExternalButtonEnterCommand =>
            _externalButtonEnterCommand!.Value;


        #endregion


        #region Methods

        protected override void HandleParameters(
            DialogAwareParameters parameters)
        {
            _externalButtonEnterCommand = new Lazy<ICommand>(
                (ICommand)parameters[Parameters.ButtonEnterCommand]!);
        }

        #endregion

        #region Events

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (!ExecutionComplete)
                e.Cancel = true;
        }

        #endregion


        #region Nested

        public static class Parameters
        {
            public const string ButtonEnterCommand = nameof(ButtonEnterCommand);
        }

        private void ButtonCommandExecute([CallerMemberName] string prop = "")
        {
            OutputText += prop;
        }

        private void ButtonClearCommandExecute()
        {
            OutputText = string.Empty;
        }

        private Task ButtonEnterCommandExecute(object? value)
        {
            try
            {
                ExternalButtonEnterCommand.Execute(OutputText);
                _inputExpected = false;
                OutputText=string.Empty;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return Task.CompletedTask;
        }

        #endregion
    }
}
