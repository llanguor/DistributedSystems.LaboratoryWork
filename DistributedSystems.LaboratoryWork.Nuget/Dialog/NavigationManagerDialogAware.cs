using DistributedSystems.LaboratoryWork.Nuget.ViewModel;
using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DistributedSystems.LaboratoryWork.Nuget.Dialog
{
    public sealed class NavigationManagerDialogAware:
        IDialogAware
    {
        #region Fields

        private readonly Dictionary<Type, Type> _viewTypeToViewMappings;

        private readonly IResolver _resolver;

        #endregion

        #region Constructors

        public NavigationManagerDialogAware(IResolver resolver)
        {
            _viewTypeToViewMappings = [];
            _resolver = resolver;
        }

        #endregion

        #region Methods

        public NavigationManagerDialogAware AddMapping<TView, TViewModel>()
            where TView :
                Window
            where TViewModel :
                DialogViewModelBase
        {
            _viewTypeToViewMappings.Add(
                typeof(TViewModel),
                typeof(TView));

            return this;
        }


        public bool ShowDialog(
            DialogAwareParameters dialogParameters)
        {
            if (!_viewTypeToViewMappings.TryGetValue(dialogParameters.DialogType, out var dialogWindowFactory))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(dialogParameters), "Factory for dialog was not registred!");
            }
        
            Window dialogControl = (_resolver.Resolve(dialogWindowFactory) as Window)!;
            var dialogControlViewModel = dialogControl.DataContext as DialogViewModelBase;

            if (dialogControlViewModel is null)
            {
                throw new ArgumentException(
                    nameof(dialogParameters), "Invalid dialog view model type, or view model does not exist");
            }

            dialogControlViewModel.InputParameters = dialogParameters;
            dialogControl.Owner = System.Windows.Application.Current.MainWindow;
            dialogControl.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            return dialogControl.ShowDialog() ?? false;
        }

        public async Task<bool> ShowDialogAsync(
           DialogAwareParameters dialogParameters)
        {
            await Task.Yield();
            return ShowDialog(dialogParameters);
        }

        #endregion
    }
}
