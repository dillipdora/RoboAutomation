using RoboAutomation.Interfaces;
using RoboAutomation.Services;
using RoboAutomation.Utilities;
using RoboInfra;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace RoboAutomation.ViewModels
{
    [Export(typeof(IMainWindowViewModel))]
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private ILogger _logger;

        public List<string> CommandList { get; set; }

        public List<string> RobotList { get; set; }

        public int SelectedRobotIndex { get; set; }

        public string SelectedCommand { get; set; }

        public int SelectedReplayRobotIndex { get; set; }

        public ObservableCollection<string> ExecutedCommandText { get; private set; }

        [Import(typeof(ICommandRepository))]
        public ICommandRepository CommandRepository { get; set; }

        [Import(typeof(IRobotCommandExecuter))]
        public IRobotCommandExecuter RobotCommandExecuter { get; set; }

        [ImportingConstructor]
        public MainWindowViewModel(ILogger logger)
        {
            _logger = logger;

            FetchRobotList();
            FetchCommandsAvailable();

            //init wpf commands
            PlayCommand = new MVVMRelayCommand(PlayCommand_Execute, PlayCommand_CanExecute);
            ReplayCommand = new MVVMRelayCommand(ReplayCommand_Execute, ReplayCommand_CanExecute);

            //init in memory collection of robot commands
            ExecutedCommandText = new ObservableCollection<string>();
        }

        private async void PlayCommand_Execute(object parameter)
        {
            var cmd = new RobotCommand(SelectedRobotIndex, SelectedCommand, Double.Parse(Payload));
            await RobotCommandExecuter.ExecuteAsync(cmd);

            //add to in memory repo
            CommandRepository.Add(cmd);

            //update UI
            ExecutedCommandText.Add(GetCommandText(cmd));
        }

        private bool PlayCommand_CanExecute(object parameter)
        {
            if (Double.TryParse(parameter.ToString(), out double payload))
                return true;
            else
                return false;
        }

        private async void ReplayCommand_Execute(object obj)
        {
            var cmds = CommandRepository.GetAll();

            foreach (var cmd in cmds)
                cmd.RobotIndex = SelectedReplayRobotIndex;

            await RobotCommandExecuter.ExecuteAsync(cmds);

            int roboIndex = SelectedReplayRobotIndex + 1;
            MessageBox.Show($"Replay commands completed for Robot{roboIndex}");
        }

        private bool ReplayCommand_CanExecute(object arg)
        {
            return true;
        }

        private string GetCommandText(IRobotCommand cmd)
        {
            int roboIndex = SelectedRobotIndex + 1;

            if (cmd.CommandName == "Move" || cmd.CommandName == "Turn")
                return $" Robot{roboIndex} - {SelectedCommand} - {Payload}";
            else
                return $" Robot{roboIndex} - {SelectedCommand}";
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

        public MVVMRelayCommand PlayCommand { get; set; }

        public MVVMRelayCommand ReplayCommand { get; set; }
    }
}
