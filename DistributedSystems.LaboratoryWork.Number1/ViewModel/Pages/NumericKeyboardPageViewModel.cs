using DistributedSystems.LaboratoryWork.Nuget.Navigation;
using DistributedSystems.LaboratoryWork.Nuget.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using DistributedSystems.LaboratoryWork.Nuget.Command;
using System.Runtime.CompilerServices;

namespace DistributedSystems.LaboratoryWork.Number1.ViewModel.Pages
{
   

    class NumericKeyboardPageViewModel :
        PageViewModelBase
    {
        #region Constructors

        public NumericKeyboardPageViewModel(NavigationManager navigationManager) :
           base(navigationManager)
        {
            _buttonCommand = new Lazy<ICommand>(() => new RelayCommand((prop) => ButtonCommandExecute(prop.ToString())));
            _buttonClearCommand = new Lazy<ICommand>(() => new RelayCommand((prop) => ButtonClearCommandExecute(prop.ToString())));
        }

        #endregion


        #region Fields

        private string _outputText = "";

        private readonly Lazy<ICommand> _buttonCommand;

        private readonly Lazy<ICommand> _buttonClearCommand;

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

        #endregion


        #region Methods

        private void ButtonCommandExecute([CallerMemberName] string prop = "")
        {
            OutputText += prop;
        }

        private void ButtonClearCommandExecute([CallerMemberName] string prop = "")
        {
            OutputText = "";
        }

        #endregion
    }
}
