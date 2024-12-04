using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for DialogHost.xaml
    /// </summary>
    public partial class DialogHost : UserControl
    {
        public DialogHost()
        {
            InitializeComponent();
        }

        public CornerRadius DialogCornerRadius
        {
            get =>
                (CornerRadius)GetValue(DialogCornerRadiusProperty);

            set =>
                SetValue(DialogCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty DialogCornerRadiusProperty 
            = DependencyProperty.Register(
                nameof(DialogCornerRadius), 
                typeof(CornerRadius), 
                typeof(DialogHost), 
                new PropertyMetadata(new CornerRadius(0,0,0,0)));

        public double BackgroundOpacity
        {
            get =>
                (double)GetValue(BackgroundOpacityProperty);

            set =>
                SetValue(BackgroundOpacityProperty, value);
        }

        public static readonly DependencyProperty BackgroundOpacityProperty
            = DependencyProperty.Register(
                nameof(BackgroundOpacity),
                typeof(double),
                typeof(DialogHost),
                new PropertyMetadata(0.4));

        public ICommand BackgroundCommand
        {
            get =>
                (ICommand)GetValue(BackgroundCommandProperty);

            set =>
                SetValue(BackgroundCommandProperty, value);
        }

        public static readonly DependencyProperty BackgroundCommandProperty
            = DependencyProperty.Register(
                nameof(BackgroundCommand),
                typeof(ICommand),
                typeof(DialogHost));

    }
}
