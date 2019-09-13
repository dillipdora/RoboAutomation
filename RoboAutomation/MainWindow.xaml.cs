using RobosLibrary;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel.Composition;
using RoboAutomation.Utilities;
using RoboInfra;
using RoboAutomation.Interfaces;

namespace RoboAutomation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SatisfyImports();

            DataContext = _viewModel;
        }

        [Import(typeof(IMainWindowViewModel))]
        private IMainWindowViewModel _viewModel;

        private void SatisfyImports()
        {
            var conatiner = new MEFContainer();
            conatiner.SatisfyImports(this);
        }

    }
}
