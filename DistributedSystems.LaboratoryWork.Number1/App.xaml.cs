using DistributedSystems.LaboratoryWork.Number1.Packages.Utils.Navigations;
using System.Configuration;
using System.Data;
using System.Windows;
using DryIoc;
using DistributedSystems.LaboratoryWork.Number1.ViewModel;

namespace DistributedSystems.LaboratoryWork.Number1
{
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
                .RegisterNavigation();

            Container.Resolve<MainWindow>().Show();
        }

        #endregion

        #region Methods

        private App RegisterLogging()
        {
            return this;
        }

        private App RegisterConfiguration()
        {
            return this;
        }

        private App RegisterWindowsViews()
        {
            Container.Register<MainWindow>(Reuse.Singleton);

            return this;
        }

        private App RegisterPagesViews()
        {
            return this;
        }

        private App RegisterDialogsViews()
        {
            return this;
        }

        private App RegisterViews()
        {
            return RegisterWindowsViews()
                .RegisterPagesViews()
                .RegisterDialogsViews();
        }

        private App RegisterWindowsViewModels()
        {
            Container.Register<MainWindowViewModel>(Reuse.Singleton);
            return this;
        }

        private App RegisterPagesViewModels()
        {
            return this;
        }

        private App RegisterDialogsViewModels()
        {
            return this;
        }

        private App RegisterViewModels()
        {
            return RegisterWindowsViewModels()
                .RegisterPagesViewModels()
                .RegisterDialogsViewModels();
        }

        private App RegisterNavigation()
        {
            var navigationManager = new NavigationManager();
            Container.RegisterInstance(navigationManager);

            /*
            navigationManager
                .AddMapping<HelloWPFPage, HelloWPFPageViewModel>()
            */

            return this;
        }

        #endregion
    }

}
