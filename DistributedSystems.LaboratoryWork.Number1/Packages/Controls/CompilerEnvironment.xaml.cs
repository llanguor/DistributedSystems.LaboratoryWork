using DistributedSystems.LaboratoryWork.Nuget.Command;
using DistributedSystems.LaboratoryWork.Number1.Packages.Types;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
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
            //ко всему надо using? и dispose в класс



            MemoryStream memoryStream = new MemoryStream(new byte[255]);
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);


            binaryWriter.Write(543);
            binaryWriter.Write(551);

            memoryStream.Position = 0;
            using (BinaryReader reader = new BinaryReader(memoryStream))
            {
                int? readNumber;
                while ((readNumber = reader.ReadInt32()) != null)
                {
                    if (readNumber == 0) break;
                    MessageBox.Show(readNumber.ToString());

                }
            }
        }
    }
}
