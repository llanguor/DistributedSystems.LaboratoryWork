using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistributedSystems.LaboratoryWork.Nuget.ViewModel;

namespace DistributedSystems.LaboratoryWork.Number1.ViewModel.Dialogs
{
    internal class CompilerEnvironmentDialogViewModel:
        ViewModelBase
    {

        string _consoleOut = "";

        public string ConsoleOut
        {
            get => _consoleOut;

            set
            {
                _consoleOut = value; 
                RaisePropertyChanged(nameof(ConsoleOut));
            }
        }
        
    }
}
