using DistributedSystems.LaboratoryWork.Nuget.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystems.LaboratoryWork.Nuget.ViewModel
{
    public class DialogViewModelBase:
        ViewModelBase
    {

        #region Constructors

        //для всех наследников гарантируем наличие конструктора без параметров
        protected DialogViewModelBase()
        {

        }

        #endregion

        #region Fields

        private bool _dialogResult;

        #endregion

        #region Properties

        public bool DialogResult
        {
            get => _dialogResult;
            set
            {
                _dialogResult = value;
                RaisePropertyChanged(nameof(DialogResult));
            }
        }

        public DialogAwareParameters InputParameters
        {
            set
            {
                HandleParameters(
                    value ?? throw new ArgumentNullException(nameof(value)));
            }
        }

        #endregion

        #region Methods
        protected virtual void HandleParameters(
            DialogAwareParameters parameters)
        {
            
        }

        #endregion

    }
}
