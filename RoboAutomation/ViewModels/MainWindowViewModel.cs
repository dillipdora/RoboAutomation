using RoboAutomation.Interfaces;
using RoboAutomation.Services;
using RoboInfra;
using RobosLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace RoboAutomation.ViewModels
{
    [Export(typeof(IMainWindowViewModel))]
    public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
    {
        private readonly ILogger _logger;

        public List<string> CommandList { get; set; }

        public List<string> RobotList { get; set; }

        [ImportingConstructor]
        public MainWindowViewModel(ILogger logger)
        {
            _logger = logger;

            FetchRobotList();
            FetchCommandsAvailable();
        }

        private void FetchRobotList()
        {
            _logger.LogInfo("Fetching available robots");
            RobotList = new List<string>();

            int robotCount = 0;
            foreach(var robot in RobotRepository.Instance.Robots)
            {
                RobotList.Add($"Robot" + ++robotCount);
            }
        }

        private void FetchCommandsAvailable()
        {
            _logger.LogInfo("Fetching available commands");
            CommandList = new List<string>();
            CommandList.AddRange(RobotRepository.Instance.Commands);
        }

        public string Payload { get; set; }


        //todo: is it required.
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion
    }
}
