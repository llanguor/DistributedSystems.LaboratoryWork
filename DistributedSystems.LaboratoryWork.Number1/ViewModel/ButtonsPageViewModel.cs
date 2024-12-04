using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using DistributedSystems.LaboratoryWork.Nuget.Command;
using DistributedSystems.LaboratoryWork.Number1.ViewModel.Base;
using DistributedSystems.LaboratoryWork.Number1.Packages.Utils.Navigations;

namespace DistributedSystems.LaboratoryWork.Number1.ViewModel
{
    class ButtonsPageViewModel : PageViewModelBase
    {
        public ButtonsPageViewModel(NavigationManager navigationManager) :
            base(navigationManager)
        {
            _dialogHostCommand = new Lazy<ICommand>(() => new RelayCommand(_ => DialogHostCommandExecute()));
            _positiveCommand = new Lazy<ICommand>(() => new RelayCommand(_ => PositiveCommandExecute()));
            _negativeCommand = new Lazy<ICommand>(() => new RelayCommand(_ => NegativeCommandExecute()));
        }


        private readonly Lazy<ICommand> _dialogHostCommand;

        public ICommand DialogHostCommand =>
        _dialogHostCommand.Value;

        private void DialogHostCommandExecute()
        {
            MessageBox.Show("Command executed");
        }

        private readonly Lazy<ICommand> _positiveCommand;

        public ICommand PositiveCommand =>
        _positiveCommand.Value;

        private void PositiveCommandExecute()
        {
            MessageBox.Show("Positive command executed");
        }

        private readonly Lazy<ICommand> _negativeCommand;

        public ICommand NegativeCommand =>
        _negativeCommand.Value;

        private void NegativeCommandExecute()
        {
            MessageBox.Show("Negative command executed");
        }
    }
}
