using DistributedSystems.LaboratoryWork.Nuget.Navigation;

namespace DistributedSystems.LaboratoryWork.Nuget.ViewModel;

/// <summary>
/// 
/// </summary>
public abstract class PageViewModelBase :
    ViewModelBase,
    INavigatable
{

    #region Constructors

    protected PageViewModelBase(
        NavigationManager navigationManager)
    {
        NavigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
    }

    protected NavigationManager NavigationManager
    {
        get;
    }

    public virtual void OnNavigatingFrom(
        NavigationContext navigationContext)
    {

    }

    public virtual void OnNavigatedFrom(
        NavigationContext navigationContext)
    {

    }

    public virtual void OnNavigatedTo(
        NavigationContext navigationContext)
    {

    }

    #endregion

}