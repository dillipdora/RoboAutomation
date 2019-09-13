using RoboAutomation.Interfaces;
using RoboInfra;
using RobosLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboAutomation.Services
{
    [Export(typeof(IRegisterRobots))]
    public class RegisterRobotService : IRegisterRobots
    {
        private readonly ILogger _logger;
        private IRobotFactory _robotFactory;
        private IEnumerable<IRobot> _robots;

        [ImportingConstructor]
        public RegisterRobotService(ILogger logger, IRobotFactory robotFactory)
        {
            _logger = logger;
            _robotFactory = robotFactory;

            FetchRobotsFromLibrary();
        }

        private void FetchRobotsFromLibrary()
        {
            _logger.LogInfo("Fetching Robots from library");
            _robots = _robotFactory.GetRegisteredRobots();
        }

        public void RegisterAll()
        {
            _logger.LogInfo("Store all robots fetched from Robo Libary");
            RobotRepository.Instance.RegisterRobot(_robots);
        }

    }
}
