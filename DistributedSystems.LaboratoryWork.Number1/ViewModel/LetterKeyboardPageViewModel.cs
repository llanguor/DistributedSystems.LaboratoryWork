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

namespace DistributedSystems.LaboratoryWork.Number1.ViewModel
{
    class LetterKeyboardPageViewModel :
        PageViewModelBase
    {
        public LetterKeyboardPageViewModel(NavigationManager navigationManager) :
           base(navigationManager)
        {
            _buttonCommand = new Lazy<ICommand>(() => new RelayCommand((prop) => ButtonCommandExecute(prop.ToString())));
            _buttonClearCommand = new Lazy<ICommand>(() => new RelayCommand(_ => ButtonClearCommandExecute()));
            _buttonClearAllCommand = new Lazy<ICommand>(() => new RelayCommand(_ => ButtonClearAllCommandExecute()));
            _buttonEnterCommand = new Lazy<ICommand>(() => new RelayCommand(_ => ButtonEnterCommandExecute()));

        }

        private string _outputText = "";


        public string OutputText
        {
            get => _outputText;
            set
            {
                _outputText = value;
                RaisePropertiesChanged(nameof(OutputText));
            }
        }

        private readonly Lazy<ICommand> _buttonCommand;

        public ICommand ButtonCommand =>
        _buttonCommand.Value;

        private void ButtonCommandExecute([CallerMemberName] string prop = "")
        {
            OutputText += prop;
        }

        private readonly Lazy<ICommand> _buttonClearCommand;

        public ICommand ButtonClearCommand =>
        _buttonClearCommand.Value;

        private void ButtonClearCommandExecute()
        {
           if(OutputText.Length!=0) OutputText = OutputText.Remove(OutputText.Length - 1);
        }

        private readonly Lazy<ICommand> _buttonClearAllCommand;

        public ICommand ButtonClearAllCommand =>
        _buttonClearAllCommand.Value;

        private void ButtonClearAllCommandExecute()
        {
            OutputText = "";
        }

        private readonly Lazy<ICommand> _buttonEnterCommand;

        public ICommand ButtonEnterCommand =>
        _buttonEnterCommand.Value;

        private void ButtonEnterCommandExecute()
        {
            OutputText += "\r\n";
        }
    }
}
