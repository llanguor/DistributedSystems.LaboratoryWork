using DistributedSystems.LaboratoryWork.Number1.ViewModel.Dialogs;
using DryIoc;
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
using System.Windows.Shapes;

namespace DistributedSystems.LaboratoryWork.Number1.View.Dialogs
{
    /// <summary>
    /// Interaction logic for SpinnerDialog.xaml
    /// </summary>
    public partial class SpinnerDialog : Window
    {
        public SpinnerDialog()
        {
            InitializeComponent();
            DataContext = App.Container.Resolve<SpinnerDialogViewModel>();
        }
    }
}
