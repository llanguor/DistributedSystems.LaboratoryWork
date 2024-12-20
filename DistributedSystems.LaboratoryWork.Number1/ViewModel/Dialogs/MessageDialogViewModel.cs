using DistributedSystems.LaboratoryWork.Nuget.ViewModel;
using DistributedSystems.LaboratoryWork.Number1.Packages.Controls;
using DistributedSystems.LaboratoryWork.Number1.Packages.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using DistributedSystems.LaboratoryWork.Nuget.Dialog;
using DistributedSystems.LaboratoryWork.Number1.View.Dialogs;
using DistributedSystems.LaboratoryWork.Nuget.Command;
using System.Runtime.CompilerServices;

namespace DistributedSystems.LaboratoryWork.Number1.ViewModel.Dialogs
{
    //TODO: во всем проекте расставить исключения на поля на случай если они null (на запись)

    internal sealed class MessageDialogViewModel:
        DialogChoiceViewModelBase
    {
        #region Methods
        protected override void HandleParameters(
            DialogAwareParameters parameters)
        {
            //MessageDialogTypes.DialogType DialogTypeValue
            //ScrollBarVisibility ScrollViewerVisible
            //ICommand DialogHostCommand
            //ICommand PositiveCommand
            //ICommand NegativeCommand
            //string Text
            //Brush ScrollViewerBackground

            Text = (parameters[Parameters.Text] as string)!;
            ScrollViewerBackground = (parameters[Parameters.ScrollViewerBackground] as Brush)!;
            DialogHostCommand = (parameters[Parameters.DialogHostCommand] as ICommand)!;
            PositiveCommand = (parameters[Parameters.PositiveCommand] as ICommand)!;
            NegativeCommand = (parameters[Parameters.NegativeCommand] as ICommand)!;

            DialogTypeValue = (MessageDialogTypes.DialogType)parameters[Parameters.DialogTypeValue]!;
            ScrollViewerVisible = (ScrollBarVisibility)parameters[Parameters.DialogTypeValue]!;
        }

        #endregion


        #region Fields

        ScrollBarVisibility _scrollBarVisibility;

        Brush? _brushBackground;

        public string? _text;

        MessageDialogTypes.DialogType _dialogType;

        private ICommand? _dialogHostCommand;

        #endregion


        #region Style Properties

        public MessageDialogTypes.DialogType DialogTypeValue
        {
            get => _dialogType;

            set
            {
                _dialogType = value;
                RaisePropertyChanged(nameof(DialogTypeValue));
            }
        }

        public string Text
        {
            get => _text!;

            set
            {
                _text = value;
                RaisePropertyChanged(nameof(Text));
            }
        }

        public ScrollBarVisibility ScrollViewerVisible
        {
            get => _scrollBarVisibility;

            set
            {
                _scrollBarVisibility = value;
                RaisePropertyChanged(nameof(ScrollViewerVisible));
            }
        }

        public Brush ScrollViewerBackground
        {
            get => _brushBackground!;

            set
            {
                _brushBackground = value;
                RaisePropertyChanged(nameof(ScrollViewerBackground));
            }
        }

        #endregion


        #region Commands Properties

        public ICommand DialogHostCommand
        {
            get =>
                _dialogHostCommand!;

            set
            {
                _dialogHostCommand = value;
                RaisePropertyChanged(nameof(DialogHostCommand));
            }
        }

        #endregion
       

        #region Nested

        public static class Parameters
        {
            public const string DialogTypeValue = nameof(DialogTypeValue);

            public const string Text = nameof(Text);

            public const string ScrollViewerVisible = nameof(ScrollViewerVisible);

            public const string ScrollViewerBackground = nameof(ScrollViewerBackground);

            public const string DialogHostCommand = nameof(DialogHostCommand);

            public const string PositiveCommand = nameof(PositiveCommand);

            public const string NegativeCommand = nameof(NegativeCommand);
        }

        #endregion
    }
}
