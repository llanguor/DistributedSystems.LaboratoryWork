using DistributedSystems.LaboratoryWork.Number1.Packages.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static DistributedSystems.LaboratoryWork.Number1.Packages.Types.CompilerEnvironmentTypes;

namespace DistributedSystems.LaboratoryWork.Number1.Packages.Controls
{
    public partial class CompilerEnvironment : UserControl
    {
        public CompilerEnvironment()
        {
            InitializeComponent();
            Instructions = [new CompilerEnvironmentTypes.Instruction(19, 10, 10, 4)];
        }

        public ObservableCollection<CompilerEnvironmentTypes.Instruction> Instructions
        {
            get => (ObservableCollection<CompilerEnvironmentTypes.Instruction>)GetValue(instructionsProperty);
            set => SetValue(instructionsProperty, value);
        }

        public static readonly DependencyProperty instructionsProperty = DependencyProperty.Register(
            nameof(Instructions),
            typeof(ObservableCollection<CompilerEnvironmentTypes.Instruction>),
            typeof(CompilerEnvironment));
    }
}
