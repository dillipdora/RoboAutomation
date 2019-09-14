using RoboAutomation.Interfaces;
using RoboAutomation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboAutomation.Utilities
{
    public class RobotCommand : IRobotCommand
    {
        public int RobotIndex { get; set; }

        public string CommandName { get; set; }

        public double Value { get; set; }

        public RobotCommand(int robotIndex, string commandName, double value)
        {
            RobotIndex = robotIndex;
            CommandName = commandName;
            Value = value;
        }
    }
}
