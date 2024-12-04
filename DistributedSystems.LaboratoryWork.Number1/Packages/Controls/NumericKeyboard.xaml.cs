using System;
using System.Collections.Generic;
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

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Controls
{
    /// <summary>
    /// Interaction logic for NumericKeyboard.xaml
    /// </summary>
    public partial class NumericKeyboard : UserControl
    {
        public NumericKeyboard()
        {
            InitializeComponent();
        }




        public Style ButtonsStyle
        {
            get =>
                (Style)GetValue(ButtonStyleProperty);

            set =>
                SetValue(ButtonStyleProperty, value);
        }

        public static readonly DependencyProperty ButtonStyleProperty
            = DependencyProperty.Register(
                nameof(ButtonsStyle),
                typeof(Style),
                typeof(NumericKeyboard));


        public Style ButtonClearStyle
        {
            get =>
                (Style)GetValue(ButtonClearStyleProperty);

            set =>
                SetValue(ButtonClearStyleProperty, value);
        }

        public static readonly DependencyProperty ButtonClearStyleProperty
            = DependencyProperty.Register(
                nameof(ButtonClearStyle),
                typeof(Style),
                typeof(NumericKeyboard));


        public ICommand ButtonsCommand
        {
            get =>
                (ICommand)GetValue(ButtonsCommandProperty);

            set =>
                SetValue(ButtonsCommandProperty, value);
        }

        public static readonly DependencyProperty ButtonsCommandProperty
            = DependencyProperty.Register(
                nameof(ButtonsCommand),
                typeof(ICommand),
                typeof(NumericKeyboard));

        public ICommand ButtonClearCommand
        {
            get =>
                (ICommand)GetValue(ButtonClearCommandProperty);

            set =>
                SetValue(ButtonClearCommandProperty, value);
        }

        public static readonly DependencyProperty ButtonClearCommandProperty
            = DependencyProperty.Register(
                nameof(ButtonClearCommand),
                typeof(ICommand),
                typeof(NumericKeyboard));
    }
}
