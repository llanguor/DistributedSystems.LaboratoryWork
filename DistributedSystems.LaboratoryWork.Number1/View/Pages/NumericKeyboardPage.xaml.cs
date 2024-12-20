using DistributedSystems.LaboratoryWork.Number1.ViewModel.Windows;
using DistributedSystems.LaboratoryWork.Number1.ViewModel.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DistributedSystems.LaboratoryWork.Number1.View.Pages
{
    /// <summary>
    /// Interaction logic for NumericKeyboardPage.xaml
    /// </summary>
    public partial class NumericKeyboardPage : Page
    {
        public NumericKeyboardPage()
        {
            InitializeComponent();
            DataContext = App.Container.Resolve<NumericKeyboardPageViewModel>();
        }
    }
}
