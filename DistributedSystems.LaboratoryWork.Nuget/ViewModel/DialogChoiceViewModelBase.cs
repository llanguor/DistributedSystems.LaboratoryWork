using DistributedSystems.LaboratoryWork.Nuget.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DistributedSystems.LaboratoryWork.Nuget.ViewModel
{
    public class DialogChoiceViewModelBase:
        DialogViewModelBase
    {

        #region Constructors

        public DialogChoiceViewModelBase()
        {
            _positiveCommandSupplemented = new Lazy<ICommand>(() => new RelayCommand((window) => PositiveCommandSupplementedExecute(window)));
            _negativeCommandSupplemented = new Lazy<ICommand>(() => new RelayCommand((window) => NegativeCommandSupplementedExecute(window)));
        }

        #endregion

        #region Fields

        private ICommand? _positiveCommand;

        private ICommand? _negativeCommand;

        private readonly Lazy<ICommand> _positiveCommandSupplemented;

        private readonly Lazy<ICommand> _negativeCommandSupplemented;

        #endregion

        #region Properties

        public ICommand PositiveCommandSupplemented
           => _positiveCommandSupplemented.Value;

        public ICommand NegativeCommandSupplemented 
            => _negativeCommandSupplemented.Value;

        public ICommand? PositiveCommand
        {
            get =>
                _positiveCommand;

            set
            {
                _positiveCommand = value;
                RaisePropertyChanged(nameof(PositiveCommand));
            }
        }

        public ICommand? NegativeCommand
        {
            get =>
                _negativeCommand;

            set
            {
                _negativeCommand = value;
                RaisePropertyChanged(nameof(NegativeCommand));
            }
        }

        #endregion

        #region Methods

        private void NegativeCommandSupplementedExecute([CallerMemberName] object? messageDialog = null)
        {
            if (messageDialog is null)
            {
                throw new ArgumentNullException(nameof(messageDialog));
            }

            if (messageDialog is not Window)
            {
                throw new ArgumentException(nameof(messageDialog));
            }

            NegativeCommand?.Execute(null);
            (messageDialog as Window)!.DialogResult = false;
        }

        private void PositiveCommandSupplementedExecute([CallerMemberName] object? messageDialog = null)
        {
            if (messageDialog is null)
            {
                throw new ArgumentNullException(nameof(messageDialog));
            }

            if (messageDialog is not Window)
            {
                throw new ArgumentException(nameof(messageDialog));
            }

            PositiveCommand?.Execute(null);
            (messageDialog as Window)!.DialogResult = true;
        }

        #endregion

    }
}
