using DistributedSystems.LaboratoryWork.Nuget.Command;
using DistributedSystems.LaboratoryWork.Number1.Packages.Utils.Navigations;
using DistributedSystems.LaboratoryWork.Number1.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DistributedSystems.LaboratoryWork.Number1.ViewModel.Pages
{
    class LetterKeyboardPageViewModel :
        PageViewModelBase
    {
        #region Constructors

        public LetterKeyboardPageViewModel(NavigationManager navigationManager) :
           base(navigationManager)
        {
            _buttonCommand = new Lazy<ICommand>(() => new RelayCommand((prop) => ButtonCommandExecute(prop.ToString())));
            _buttonClearCommand = new Lazy<ICommand>(() => new RelayCommand(_ => ButtonClearCommandExecute()));
            _buttonClearAllCommand = new Lazy<ICommand>(() => new RelayCommand(_ => ButtonClearAllCommandExecute()));
            _buttonEnterCommand = new Lazy<ICommand>(() => new RelayCommand(_ => ButtonEnterCommandExecute()));
        }

        #endregion


        #region Fields

        private string _outputText = "";

        private readonly Lazy<ICommand> _buttonCommand;

        private readonly Lazy<ICommand> _buttonClearCommand;

        private readonly Lazy<ICommand> _buttonClearAllCommand;

        private readonly Lazy<ICommand> _buttonEnterCommand;

        #endregion


        #region Properties

        public string OutputText
        {
            get => _outputText;
            set
            {
                _outputText = value;
                RaisePropertiesChanged(nameof(OutputText));
            }
        }

        public ICommand ButtonCommand =>
            _buttonCommand.Value;

        public ICommand ButtonClearCommand =>
            _buttonClearCommand.Value;

        public ICommand ButtonClearAllCommand =>
            _buttonClearAllCommand.Value;

        public ICommand ButtonEnterCommand =>
            _buttonEnterCommand.Value;

        #endregion


        #region Methods

        private void ButtonCommandExecute([CallerMemberName] string prop = "")
        {
            OutputText += prop;
        }

        private void ButtonClearCommandExecute()
        {
            if (OutputText.Length != 0) OutputText = OutputText.Remove(OutputText.Length - 1);
        }

        private void ButtonClearAllCommandExecute()
        {
            OutputText = "";
        }

        private void ButtonEnterCommandExecute()
        {
            OutputText += "\r\n";
        }

        #endregion
    }
}
