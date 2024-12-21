using DistributedSystems.LaboratoryWork.Number1.ViewModel.Dialogs;
using DistributedSystems.LaboratoryWork.Nuget.ViewModel;
using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DistributedSystems.LaboratoryWork.Number1.Utils.Logger
{
    internal class Logger
    {

        private Mutex mutex = new Mutex();

        public Logger()
        {
           // _resolver = App.Container;
           // _source = _resolver.Resolve<CompilerEnvironmentDialogViewModel>();
        }

        public void Log(string message)
        { 
            mutex.WaitOne();
            App.Container.Resolve<CompilerEnvironmentDialogViewModel>().ConsoleOut += $"\r\n{message}";
            mutex.ReleaseMutex();
        }

    }
}
