using DistributedSystems.LaboratoryWork.Nuget.Command;
using DistributedSystems.LaboratoryWork.Nuget.Navigation;
using DistributedSystems.LaboratoryWork.Nuget.ViewModel;
using DistributedSystems.LaboratoryWork.Number1.Packages.Utils.Navigations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DistributedSystems.LaboratoryWork.Number1.ViewModel
{
    internal class MainWindowViewModel:
        ViewModelBase
    {
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

        public MainWindowViewModel()
        {
            _dialogHostCommand = new Lazy<ICommand>(() => new RelayCommand(_ => DialogHostCommandExecute()));
            _positiveCommand = new Lazy<ICommand>(() => new RelayCommand(_ => PositiveCommandExecute()));
            _negativeCommand = new Lazy<ICommand>(() => new RelayCommand(_ => NegativeCommandExecute()));
        }

    }
}
