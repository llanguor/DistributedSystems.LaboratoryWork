using DistributedSystems.LaboratoryWork.Nuget.ViewModel;
using DistributedSystems.LaboratoryWork.Number1.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DistributedSystems.LaboratoryWork.Number1.Packages.Types;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Controls
{
    public partial class MessageDialog : UserControl
    {
        #region Constructors

        public MessageDialog()
        {
            InitializeComponent();
        }

        #endregion


        #region DependencyProprety DialogStyle 

        public MessageDialogTypes.DialogType DialogTypeValue
        {
            get =>
                (MessageDialogTypes.DialogType)GetValue(DialogTypeProperty);

            init =>
                SetValue(DialogTypeProperty, value);
        }

        public static readonly DependencyProperty DialogTypeProperty
            = DependencyProperty.Register(
                nameof(DialogTypeValue),
                typeof(MessageDialogTypes.DialogType),
                typeof(MessageDialog),
                new PropertyMetadata(MessageDialogTypes.DialogType.YesNo));

        public string Text
        {
            get =>
                (string)GetValue(TextProperty);

            set =>
                SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty
            = DependencyProperty.Register(
                nameof(Text),
                typeof(string),
                typeof(MessageDialog));

        public ScrollBarVisibility ScrollViewerVisible
        {
            get =>
                (ScrollBarVisibility)GetValue(ScrollViewerVisibleProperty);

            set =>
                SetValue(ScrollViewerVisibleProperty, value);
        }

        public static readonly DependencyProperty ScrollViewerVisibleProperty
            = DependencyProperty.Register(
                nameof(ScrollViewerVisible),
                typeof(ScrollBarVisibility),
                typeof(MessageDialog),
                new PropertyMetadata(ScrollBarVisibility.Auto));

        public Brush ScrollViewerBackground
        {
            get =>
                (Brush)GetValue(ScrollViewerBackgroundProperty);

            set =>
                SetValue(ScrollViewerBackgroundProperty, value);
        }

        public static readonly DependencyProperty ScrollViewerBackgroundProperty
            = DependencyProperty.Register(
                nameof(ScrollViewerBackground),
                typeof(Brush),
                typeof(MessageDialog),
                new PropertyMetadata(Brushes.DarkGray));

        #endregion


        #region DependencyProperty Commands

        public ICommand PositiveCommand
        {
            get =>
                (ICommand)GetValue(PositiveCommandProperty);

            set =>
                SetValue(PositiveCommandProperty, value);
        }

        public static readonly DependencyProperty PositiveCommandProperty
            = DependencyProperty.Register(
                nameof(PositiveCommand),
                typeof(ICommand),
                typeof(MessageDialog));

        public ICommand NegativeCommand
        {
            get =>
                (ICommand)GetValue(NegativeCommandProperty);

            set =>
                SetValue(NegativeCommandProperty, value);
        }

        public static readonly DependencyProperty NegativeCommandProperty
            = DependencyProperty.Register(
                nameof(NegativeCommand),
                typeof(ICommand),
                typeof(MessageDialog));


        #endregion
    }
}
