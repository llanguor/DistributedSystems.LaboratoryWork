using System.Windows.Input;

namespace DistributedSystems.LaboratoryWork.Nuget.Command;

public class RelayCommand(
    Action<object?> execute,
    Predicate<object?>? canExecute = null) :
    ICommand
{

    #region Fields

    private readonly Action<object?> _execute = execute ?? throw new ArgumentNullException(nameof(execute));

    private readonly Predicate<object?>? _canExecute = canExecute;

    #endregion


    #region System.Windows.Input.ICommand implementation

    public bool CanExecute(
        object? parameter)
    {
        return _canExecute?.Invoke(parameter) ?? true;
    }

    public void Execute(
        object? parameter)
    {
        _execute(parameter);
    }

    public event EventHandler? CanExecuteChanged
    {
        add =>
            CommandManager.RequerySuggested += value;

        remove =>
            CommandManager.RequerySuggested -= value;
    }

    #endregion

}