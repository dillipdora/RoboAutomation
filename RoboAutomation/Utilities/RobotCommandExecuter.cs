using RoboAutomation.Interfaces;
using RoboAutomation.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboAutomation.Utilities
{
    [Export(typeof(IRobotCommandExecuter))]
    public class RobotCommandExecuter : IRobotCommandExecuter
    {
        public Task<bool> ExecuteAsync(IRobotCommand command)
        {
            //find robot by index
            var robot = RobotRepository.Instance.Find(command.RobotIndex);

            var task = Task.Factory.StartNew(() => {
                if (command.CommandName == "Move")
                {
                    robot.Move(command.Value);
                }
                else if (command.CommandName == "Turn")
                {
                    robot.Turn(command.Value);
                }
                else
                {
                    robot.Beep();
                }
                return true;
            });

            return task;
        }

        public Task<bool> ExecuteAsync(IEnumerable<IRobotCommand> robotCommands)
        {
            bool result = false;
            foreach (var cmd in robotCommands)
            {
                result = result | ExecuteAsync(cmd).Result;
            }

            return Task.FromResult<bool>(result);
        }
    }
}
