using RoboAutomation.Interfaces;
using RoboAutomation.Utilities;
using System.ComponentModel.Composition;
using System.Windows;

namespace RoboAutomation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            SatisfyImports();

            _registerRobots.RegisterAll();
        }

        private void SatisfyImports()
        {
            DependencyInjectionHelper.Resolve(this);
        }

        [Import(typeof(IRegisterRobots))]
        IRegisterRobots _registerRobots;

    }
}
