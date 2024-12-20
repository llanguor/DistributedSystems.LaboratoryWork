using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using DistributedSystems.LaboratoryWork.Nuget.Command;
using DistributedSystems.LaboratoryWork.Nuget.ViewModel;
using DistributedSystems.LaboratoryWork.Nuget.Navigation;
using DistributedSystems.LaboratoryWork.Nuget.Dialog;
using DistributedSystems.LaboratoryWork.Number1.ViewModel.Dialogs;
using DistributedSystems.LaboratoryWork.Number1.Packages.Types;
using System.Windows.Media;
using System.Windows.Controls;
using DistributedSystems.LaboratoryWork.Number1.View.Windows;
using DistributedSystems.LaboratoryWork.Number1.Packages.Controls;

namespace DistributedSystems.LaboratoryWork.Number1.ViewModel.Pages
{
    class ButtonsPageViewModel : PageViewModelBase
    {
        #region Constructor

        public ButtonsPageViewModel(NavigationManager navigationManager, IDialogAware dialogAware) :
            base(navigationManager)
        {
            _dialogHostCommand = new Lazy<ICommand>(() => new RelayCommand(_ => DialogHostCommandExecute()));
            _positiveCommand = new Lazy<ICommand>(() => new RelayCommand(_ => PositiveCommandExecute()));
            _negativeCommand = new Lazy<ICommand>(() => new RelayCommand(_ => NegativeCommandExecute()));
            _showMessageDialog = new Lazy<ICommand>(() => new RelayCommand(_ => ShowMessageDialogExecute()));
            _showSpinnerDialog = new Lazy<ICommand>(() => new RelayCommand(_ => ShowSpinnerDialogExecute()));
            _dialogAware = dialogAware ?? throw new ArgumentNullException(nameof(dialogAware));
            _spinnerRadiusCoefficient = 0.12;
        }

        #endregion


        #region Fields

        private readonly Lazy<ICommand> _dialogHostCommand;

        private readonly Lazy<ICommand> _positiveCommand;

        private readonly Lazy<ICommand> _negativeCommand;

        private readonly Lazy<ICommand> _showMessageDialog;

        private readonly Lazy<ICommand> _showSpinnerDialog;

        private readonly IDialogAware _dialogAware;

        private readonly double _spinnerRadiusCoefficient;

        #endregion


        #region Properties

        public ICommand DialogHostCommand =>
                _dialogHostCommand.Value;

        public ICommand PositiveCommand =>
                _positiveCommand.Value;

        public ICommand NegativeCommand =>
                _negativeCommand.Value;

        public ICommand ShowMessageDialog =>
                _showMessageDialog.Value;

        public ICommand ShowSpinnerDialog =>
                _showSpinnerDialog.Value;
        
        public double SpinnerRadiusCoefficient => 
            _spinnerRadiusCoefficient;

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

        private void ShowMessageDialogExecute()
        {

            MessageBox.Show("START");
            if (_dialogAware.ShowDialog(DialogAwareParameters.Builder.Create()
            .ForDialogType<MessageDialogViewModel>()
            .AddParameter(MessageDialogViewModel.Parameters.PositiveCommand, PositiveCommand)
            .AddParameter(MessageDialogViewModel.Parameters.NegativeCommand, NegativeCommand)
            .AddParameter(MessageDialogViewModel.Parameters.DialogHostCommand, DialogHostCommand)
            .AddParameter(MessageDialogViewModel.Parameters.Text, "Some text")
            .AddParameter(MessageDialogViewModel.Parameters.DialogTypeValue, MessageDialogTypes.DialogType.OkCancel)
            .AddParameter(MessageDialogViewModel.Parameters.ScrollViewerBackground, Colors.AliceBlue)
            .AddParameter(MessageDialogViewModel.Parameters.ScrollViewerVisible, ScrollBarVisibility.Visible)
            .Build()))
            {
                System.Windows.MessageBox.Show("Dialog result: ACCEPTED");
            }
            else
            {
                System.Windows.MessageBox.Show("Dialog result: CANCELLED");
            }
        }

        private void ShowSpinnerDialogExecute()
        {
            if (_dialogAware.ShowDialog(DialogAwareParameters.Builder.Create()
            .ForDialogType<SpinnerDialogViewModel>()
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerItemsCount, 2)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerRadiusCoefficient, 0.2)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerColor, Brushes.LightGray)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerRotationDirection, Spinner.RotationDirection.Counterclockwise)
            .AddParameter(SpinnerDialogViewModel.Parameters.SpinnerSpeed, new TimeSpan(1000))
            .AddParameter(SpinnerDialogViewModel.Parameters.Text, "Please wait...")
            .AddParameter(SpinnerDialogViewModel.Parameters.FontSize, 30)
            .Build()))
            {
                System.Windows.MessageBox.Show("Dialog result: ACCEPTED");
            }
            else
            {
                System.Windows.MessageBox.Show("Dialog result: CANCELLED");
            }
        }

        #endregion
    }
}
