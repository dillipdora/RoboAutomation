using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboAutomation.Interfaces
{
    public interface IRobotCommandExecuter
    {
        Task<bool> ExecuteAsync(IRobotCommand command);

        Task<bool> ExecuteAsync(IEnumerable<IRobotCommand> command);
    }
}
