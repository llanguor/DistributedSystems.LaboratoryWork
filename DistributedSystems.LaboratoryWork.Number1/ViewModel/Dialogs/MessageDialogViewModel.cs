﻿using DistributedSystems.LaboratoryWork.Nuget.ViewModel;
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

    internal sealed class MessageDialogViewModel:
        DialogChoiceViewModelBase
    {

        #region Fields

        ScrollBarVisibility _scrollBarVerticalVisibility;

        ScrollBarVisibility _scrollBarHorizontalVisibility;

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

        public ScrollBarVisibility ScrollViewerVerticalVisible
        {
            get => _scrollBarVerticalVisibility;

            set
            {
                _scrollBarVerticalVisibility = value;
                RaisePropertyChanged(nameof(ScrollViewerVerticalVisible));
            }
        }

        public ScrollBarVisibility ScrollViewerHorizontalVisible
        {
            get => _scrollBarHorizontalVisibility;

            set
            {
                _scrollBarHorizontalVisibility = value;
                RaisePropertyChanged(nameof(ScrollViewerHorizontalVisible));
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

        public ICommand? DialogHostCommand
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

        #region Methods
        protected override void HandleParameters(
            DialogAwareParameters parameters)
        {
            Text = (parameters[Parameters.Text] as string)!;
            ScrollViewerBackground = (parameters[Parameters.ScrollViewerBackground] as Brush)!;
            DialogHostCommand = parameters[Parameters.DialogHostCommand] as ICommand;
            PositiveCommand = parameters[Parameters.PositiveCommand] as ICommand;
            NegativeCommand = parameters[Parameters.NegativeCommand] as ICommand;

            DialogTypeValue = (MessageDialogTypes.DialogType)parameters[Parameters.DialogTypeValue]!;
            ScrollViewerVerticalVisible = (ScrollBarVisibility)parameters[Parameters.ScrollViewerVerticalVisible]!;
            ScrollViewerHorizontalVisible = (ScrollBarVisibility)parameters[Parameters.ScrollViewerHorizontalVisible]!;
        }

        #endregion

        #region Nested

        public static class Parameters
        {
            public const string DialogTypeValue = nameof(DialogTypeValue);

            public const string Text = nameof(Text);

            public const string ScrollViewerVerticalVisible = nameof(ScrollViewerVerticalVisible);

            public const string ScrollViewerHorizontalVisible = nameof(ScrollViewerHorizontalVisible);

            public const string ScrollViewerBackground = nameof(ScrollViewerBackground);

            public const string DialogHostCommand = nameof(DialogHostCommand);

            public const string PositiveCommand = nameof(PositiveCommand);

            public const string NegativeCommand = nameof(NegativeCommand);
        }

        #endregion

    }
}
