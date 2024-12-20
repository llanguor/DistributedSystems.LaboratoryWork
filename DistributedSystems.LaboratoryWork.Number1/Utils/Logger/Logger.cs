using DistributedSystems.LaboratoryWork.Number1.ViewModel.Dialogs;
using DistributedSystems.LaboratoryWork.Nuget.ViewModel;
using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystems.LaboratoryWork.Number1.Utils.Logger
{
    internal class Logger
    {
        private readonly IResolver _resolver;

        private readonly ViewModelBase _source;

        private Mutex mutex = new Mutex();

        public Logger()
        {
            _resolver = App.Container;
            _source = _resolver.Resolve<CompilerEnvironmentDialogViewModel>();
        }

        public void Log(string message)
        {
            mutex.WaitOne();
            ((CompilerEnvironmentDialogViewModel)_source).ConsoleOut += $"\r\n{message}";
            mutex.ReleaseMutex();
        }

    }
}
