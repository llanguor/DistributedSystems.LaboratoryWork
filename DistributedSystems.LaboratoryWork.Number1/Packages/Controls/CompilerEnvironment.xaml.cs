using DistributedSystems.LaboratoryWork.Nuget.Command;
using DistributedSystems.LaboratoryWork.Number1.Packages.Types;
using Microsoft.Win32;
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
            Instructions = new ObservableCollection<Instruction>();
            //Instructions = [new Instruction(19, 10, 10, 4)];
            _openFileCommand = new Lazy<ICommand>(() => new RelayCommand(_ => OpenFileCommandExecute()));
            _compileCommand = new Lazy<ICommand>(() => new RelayCommand(_ => CompileCommandExecute()));
        }

        public ObservableCollection<Instruction> Instructions
        {
            get => (ObservableCollection<Instruction>)GetValue(instructionsProperty);
            set => SetValue(instructionsProperty, value);
        }

        public static readonly DependencyProperty instructionsProperty = DependencyProperty.Register(
            nameof(Instructions),
            typeof(ObservableCollection<Instruction>),
            typeof(CompilerEnvironment));



        private readonly Lazy<ICommand> _openFileCommand;

        public ICommand OpenFileCommand
            => _openFileCommand.Value;

        private void OpenFileCommandExecute()
        {
            var openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog()==false)
                return;

            string fileText = System.IO.File.ReadAllText(openFileDialog1.FileName);
            programTextBox.Text = fileText;

            programTextBox.Focus();
            programDataGrid.Focus();
        }

        private readonly Lazy<ICommand> _compileCommand;

        public ICommand CompileCommand
            => _compileCommand.Value;

        private void CompileCommandExecute()
        {
            MessageBox.Show("Compile"); //сначала сделать диалог
        }
    }
}
