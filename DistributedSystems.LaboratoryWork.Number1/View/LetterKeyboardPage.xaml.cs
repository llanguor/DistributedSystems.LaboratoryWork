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
    /// Interaction logic for LetterKeyboardPage.xaml
    /// </summary>
    public partial class LetterKeyboardPage : Page
    {
        public LetterKeyboardPage()
        {
            InitializeComponent();
            DataContext = App.Container.Resolve<LetterKeyboardPageViewModel>();
        }
    }
}
