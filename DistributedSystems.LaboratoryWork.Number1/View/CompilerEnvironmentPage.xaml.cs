using DistributedSystems.LaboratoryWork.Number1.ViewModel;
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

namespace DistributedSystems.LaboratoryWork.Number1.View
{
    /// <summary>
    /// Interaction logic for CompilerEnvironmentPage.xaml
    /// </summary>
    public partial class CompilerEnvironmentPage : Page
    {
        public CompilerEnvironmentPage()
        {
            InitializeComponent();
            DataContext = App.Container.Resolve<CompilerEnvironmentPageViewModel>();
        }
    }
}
