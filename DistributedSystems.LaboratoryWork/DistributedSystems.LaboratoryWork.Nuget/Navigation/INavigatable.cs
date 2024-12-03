namespace DistributedSystems.LaboratoryWork.Nuget.Navigation;

/// <summary>
/// 
/// </summary>
public interface INavigatable
{

    void OnNavigatingFrom(
        NavigationContext navigationContext);

    void OnNavigatedFrom(
        NavigationContext navigationContext);

    void OnNavigatedTo(
        NavigationContext navigationContext);

}