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
        #region Constructor

        public ButtonsPageViewModel(NavigationManager navigationManager) :
            base(navigationManager)
        {
            _dialogHostCommand = new Lazy<ICommand>(() => new RelayCommand(_ => DialogHostCommandExecute()));
            _positiveCommand = new Lazy<ICommand>(() => new RelayCommand(_ => PositiveCommandExecute()));
            _negativeCommand = new Lazy<ICommand>(() => new RelayCommand(_ => NegativeCommandExecute()));
        }

        #endregion


        #region Fields

        private readonly Lazy<ICommand> _dialogHostCommand;

        private readonly Lazy<ICommand> _positiveCommand;

        private readonly Lazy<ICommand> _negativeCommand;

        #endregion


        #region Properties

        public ICommand DialogHostCommand =>
       _dialogHostCommand.Value;
        public ICommand PositiveCommand =>
       _positiveCommand.Value;

        public ICommand NegativeCommand =>
       _negativeCommand.Value;

        #endregion


        #region Methods

        private void NegativeCommandExecute()
        {
            MessageBox.Show("Negative command executed");
        }

        private void DialogHostCommandExecute()
        {
            MessageBox.Show("Command executed");
        }

        private void PositiveCommandExecute()
        {
            MessageBox.Show("Positive command executed");
        }

        #endregion
    }
}
