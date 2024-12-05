using DistributedSystems.LaboratoryWork.Number1.Packages.Utils.Navigations;
using DistributedSystems.LaboratoryWork.Number1.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using DistributedSystems.LaboratoryWork.Nuget.Command;
using System.Runtime.CompilerServices;

namespace DistributedSystems.LaboratoryWork.Number1.ViewModel
{
    class NumericKeyboardPageViewModel :
        PageViewModelBase
    {
        public NumericKeyboardPageViewModel(NavigationManager navigationManager) :
           base(navigationManager)
        {
            _buttonCommand = new Lazy<ICommand>(() => new RelayCommand((prop) => ButtonCommandExecute((string)prop!)));
            _buttonClearCommand = new Lazy<ICommand>(() => new RelayCommand((prop) => ButtonClearCommandExecute((string)prop!)));
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

        private void ButtonCommandExecute([CallerMemberName] string prop="")
        {
            OutputText+=prop;
        }

        private readonly Lazy<ICommand> _buttonClearCommand;

        public ICommand ButtonClearCommand =>
        _buttonClearCommand.Value;

        private void ButtonClearCommandExecute([CallerMemberName] string prop = "")
        {
            OutputText = "";
        }
    }
}
