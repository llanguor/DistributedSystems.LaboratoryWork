using DistributedSystems.LaboratoryWork.Nuget.Dialog;
using DistributedSystems.LaboratoryWork.Nuget.ViewModel;
using DistributedSystems.LaboratoryWork.Number1.Packages.Controls;
using DistributedSystems.LaboratoryWork.Number1.Packages.Types;
using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using static DistributedSystems.LaboratoryWork.Number1.Packages.Controls.Spinner;

namespace DistributedSystems.LaboratoryWork.Number1.ViewModel.Dialogs
{
    internal class SpinnerDialogViewModel :
        DialogViewModelBase
    {
        #region Constructors

        public SpinnerDialogViewModel() 
        {
            _timer = new DispatcherTimer(new TimeSpan(0,0,0,0,600), DispatcherPriority.Normal, (sender, eventArgs) =>
            {
               TextPointsCount = TextPointsCount % 3 + 1;
            }, Dispatcher.CurrentDispatcher);
            _timer.Start();
        }


        #endregion

        #region Methods

        protected override void HandleParameters(
         DialogAwareParameters parameters)
        {
            SpinnerItemsCount = (int)parameters[Parameters.SpinnerItemsCount]!;
            SpinnerRadiusCoefficient = (double)parameters[Parameters.SpinnerRadiusCoefficient]!;
            SpinnerColor = (parameters[Parameters.SpinnerColor] as Brush)!;
            SpinnerRotationDirection = (Spinner.RotationDirection)parameters[Parameters.SpinnerRotationDirection]!;
            SpinnerSpeed = (TimeSpan)parameters[Parameters.SpinnerSpeed]!;
            Text = (parameters[Parameters.Text] as string)!;
            FontSize = (int)parameters[Parameters.FontSize]!;            
        }

        #endregion

        #region Nested

        public static class Parameters
        {
            public const string SpinnerItemsCount = nameof(SpinnerItemsCount);

            public const string SpinnerRadiusCoefficient = nameof(SpinnerRadiusCoefficient);

            public const string SpinnerColor = nameof(SpinnerColor);

            public const string SpinnerRotationDirection = nameof(SpinnerRotationDirection);

            public const string SpinnerSpeed = nameof(SpinnerSpeed);

            public const string Text = nameof(Text);

            public const string FontSize = nameof(FontSize);
        }

        #endregion

        #region Fields

        private int _spinnerItemsCount;

        private double _spinnerRadiusCoefficient;

        private Brush? _spinnerColor;

        private Spinner.RotationDirection _spinnerRotationDirection;

        private TimeSpan _spinnerSpeed;

        private string _text = "Please wait";

        private int _textPointsCount = 1;

        private int _fontSize;

        private DispatcherTimer _timer;

        private bool _loadingAnimationActive = true;

        #endregion

        #region Properties

        public bool LoadingAnimationActive
        {
            get => _loadingAnimationActive;
            set
            {
                _loadingAnimationActive = value;
                _timer.IsEnabled = value;
                TextPointsCount = 0;
                RaisePropertiesChanged(nameof(LoadingAnimationActive));
            }
        }

        public int SpinnerItemsCount
        {
            get => _spinnerItemsCount;
            set
            {
                _spinnerItemsCount = value;
                RaisePropertyChanged(nameof(SpinnerItemsCount));
            }
        }
           

        public double SpinnerRadiusCoefficient 
        {
            get => _spinnerRadiusCoefficient;
            set
            {
                _spinnerRadiusCoefficient = value;
                RaisePropertyChanged(nameof(SpinnerRadiusCoefficient));
            }
        }

        public Brush SpinnerColor
        {
            get => _spinnerColor!;
            set
            {
                _spinnerColor = value;
                RaisePropertyChanged(nameof(SpinnerColor));
            }
        }

        public TimeSpan SpinnerSpeed
        {
            get => _spinnerSpeed;
            set
            {
                _spinnerSpeed = value;
                RaisePropertyChanged(nameof(SpinnerSpeed));
            }
        }

        public Spinner.RotationDirection SpinnerRotationDirection
        {
            get => _spinnerRotationDirection;
            set
            {
                _spinnerRotationDirection = value;
                RaisePropertyChanged(nameof(SpinnerRotationDirection));
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                RaisePropertyChanged(nameof(Text));
            }
        }

        public int TextPointsCount
        {
            get => _textPointsCount;
            set
            {
                _textPointsCount = value;
                RaisePropertyChanged(nameof(TextPointsCount));
            }
        }

        public int FontSize 
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                RaisePropertyChanged(nameof(FontSize));
            }
        }

        #endregion
      
    }
}
