using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DistributedSystems.LaboratoryWork.Nuget.Dialog
{
    public interface IDialogAware
    {
        bool ShowDialog(DialogAwareParameters dialogAwareParameters);

        public Task<bool> ShowDialogAsync(DialogAwareParameters dialogParameters);
    }
}
