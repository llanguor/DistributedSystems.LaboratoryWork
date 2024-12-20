using System.Configuration;
using System.Data;
using System.Windows;
using DryIoc;
using DistributedSystems.LaboratoryWork.Number1.View.Pages;
using DistributedSystems.LaboratoryWork.Number1.View.Windows;
using DistributedSystems.LaboratoryWork.Number1.View.Dialogs;
using DistributedSystems.LaboratoryWork.Number1.ViewModel.Pages;
using DistributedSystems.LaboratoryWork.Number1.ViewModel.Windows;
using DistributedSystems.LaboratoryWork.Number1.ViewModel.Dialogs;
using DistributedSystems.LaboratoryWork.Nuget.ViewModel;
using DistributedSystems.LaboratoryWork.Nuget.Navigation;
using DistributedSystems.LaboratoryWork.Number1.Utils.Logger;
using DistributedSystems.LaboratoryWork.Nuget.Dialog;

namespace DistributedSystems.LaboratoryWork.Number1
{
   
    //TODO: Binding OneWay everywhere.

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields

        private static readonly Lazy<IContainer> _container;

        #endregion

        #region Constructors

        static App()
        {
            _container = new Lazy<IContainer>(() => new Container());
        }

        #endregion

        #region Properties
        public static IContainer Container =>
        _container.Value;

        #endregion

        #region System.Windows.Application overrides

        protected override void OnStartup(
            StartupEventArgs e)
        {
            this.RegisterLogging()
                .RegisterConfiguration()
                .RegisterViews()
                .RegisterViewModels()
                .RegisterNavigationDialogAware()
                .RegisterNavigation();

            Container.Resolve<MainWindow>().Show();
        }

        #endregion

        #region Methods

        private App RegisterLogging()
        {
            // using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
            // ILogger logger = factory.CreateLogger("Program");

            Container.Register<Logger>();
            return this;
        }

        private App RegisterConfiguration()
        {
            return this;
        }

        #endregion



        #region Navigations Methods

        private App RegisterNavigation()
        {
            var navigationManager = new NavigationManager(Container);
            Container.RegisterInstance(navigationManager);

            navigationManager
                .AddMapping<ButtonsPage, ButtonsPageViewModel>()
                .AddMapping<NumericKeyboardPage, NumericKeyboardPageViewModel>()
                .AddMapping<LetterKeyboardPage, LetterKeyboardPageViewModel>()
                .AddMapping<CompilerEnvironmentPage, CompilerEnvironmentPageViewModel>();

            return this;
        }

        private App RegisterNavigationDialogAware()
        {
            var navigationManager = new NavigationManagerDialogAware(Container);
            Container.RegisterInstance(navigationManager);
            Container.RegisterMapping<IDialogAware, NavigationManagerDialogAware>();

            navigationManager
                .AddMapping<MessageDialog, MessageDialogViewModel>()
                .AddMapping<SpinnerDialog, SpinnerDialogViewModel>();

            return this;
        }

        #endregion

        #region Views Methods

        private App RegisterViews()
        {
            return RegisterWindowsViews()
                .RegisterPagesViews()
                .RegisterDialogsViews();
        }
        private App RegisterViewModels()
        {
            return RegisterWindowsViewModels()
                .RegisterPagesViewModels()
                .RegisterDialogsViewModels();
        }

        #endregion

        #region Pages Methods

        private App RegisterPagesViews()
        {
            Container.Register<ButtonsPage>(Reuse.Singleton);
            Container.Register<NumericKeyboardPage>(Reuse.Singleton);
            Container.Register<LetterKeyboardPage>(Reuse.Singleton);
            Container.Register<CompilerEnvironmentPage>(Reuse.Singleton);
            return this;
        }

        private App RegisterPagesViewModels()
        {
            Container.Register<ButtonsPageViewModel>(Reuse.Singleton);
            Container.Register<NumericKeyboardPageViewModel>(Reuse.Singleton);
            Container.Register<LetterKeyboardPageViewModel>(Reuse.Singleton);
            Container.Register<CompilerEnvironmentPageViewModel>(Reuse.Singleton);
            return this;
        }

        #endregion

        #region Dialogs Methods

        private App RegisterDialogsViews()
        {
            Container.Register<MessageDialog>(Reuse.Transient);
            Container.Register<SpinnerDialog>(Reuse.Transient);
            Container.Register<CompilerEnvironmentDialog>(Reuse.Transient);
            return this;
        }

        private App RegisterDialogsViewModels()
        {
            Container.Register<MessageDialogViewModel>(Reuse.Transient);
            Container.Register<SpinnerDialogViewModel>(Reuse.Transient);
            Container.Register<CompilerEnvironmentDialogViewModel>(Reuse.Transient);

            return this;
        }

        #endregion

        #region Windows Methods

        private App RegisterWindowsViews()
        {
            Container.Register<MainWindow>(Reuse.Singleton);

            return this;
        }

        private App RegisterWindowsViewModels()
        {
            Container.Register<MainWindowViewModel>(Reuse.Singleton);

            return this;
        }

        #endregion 
    }

}
