﻿using DistributedSystems.LaboratoryWork.Number1.ViewModel.Dialogs;
using DistributedSystems.LaboratoryWork.Number1.ViewModel.Windows;
using DryIoc;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DistributedSystems.LaboratoryWork.Number1.View.Dialogs
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class CompilerEnvironmentDialog : Window
    {
        public CompilerEnvironmentDialog()
        {
            InitializeComponent();

            DataContext = App.Container.Resolve<CompilerEnvironmentDialogViewModel>();
            Closing += (DataContext as CompilerEnvironmentDialogViewModel)!.OnWindowClosing!;
        }
    }
}
