using DistributedSystems.LaboratoryWork.Number1.Packages.Utils.Navigations;
using DistributedSystems.LaboratoryWork.Number1.View;
using DistributedSystems.LaboratoryWork.Number1.ViewModel;
using DryIoc;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DistributedSystems.LaboratoryWork.Number1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.Container.Resolve<MainWindowViewModel>();
        }

        private void MainWindow_OnLoaded(
            object sender,
            RoutedEventArgs e)
        {
            // App.Container.Resolve<NavigationManager>().NavigationService = frameButtons.NavigationService;
            buttonsFrame.Navigate(App.Container.Resolve<ButtonsPage>());
            numericKeyboardFrame.Navigate(App.Container.Resolve<NumericKeyboardPage>());
            letterKeyboardFrame.Navigate(App.Container.Resolve<LetterKeyboardPage>()); 
        }
    }
}