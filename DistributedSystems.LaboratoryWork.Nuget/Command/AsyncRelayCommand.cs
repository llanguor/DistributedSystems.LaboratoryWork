using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DistributedSystems.LaboratoryWork.Nuget.Command
{
    public class AsyncRelayCommand :
        ICommand
    {
        #region Fields

        private readonly Func<object?, Task> _execute;

        private readonly Predicate<object?>? _canExecute;

        #endregion

        #region Constructors

        public AsyncRelayCommand(
            Func<object?,Task> execute,
            Predicate<object?>? canExecute = null)
        {
            _canExecute = canExecute;
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        #endregion

        #region System.Windows.Input.ICommand implementation

        public bool CanExecute(
            object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                await ExecuteAsync(parameter);
            }
            catch(Exception ex)
            {
                /*
                //Перенаправляем исключение в основной поток
                //В коммерции это плохо?
                //Тут это для демонстрации учебной задачи и учёта исключений

                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    throw ex;
                });
                */
            }
        }

        public async Task ExecuteAsync(object? parameter)
        {
            await _execute(parameter);
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
}
