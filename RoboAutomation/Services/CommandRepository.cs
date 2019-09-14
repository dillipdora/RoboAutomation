using RoboAutomation.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboAutomation.Services
{
    [Export(typeof(ICommandRepository))]
    public class CommandRepository : ICommandRepository
    {
        List<IRobotCommand> _robotCommands;

        public CommandRepository()
        {
            _robotCommands = new List<IRobotCommand>();
        }

        public void Add(IRobotCommand cmd)
        {
            _robotCommands.Add(cmd);
        }

        public void Clear()
        {
            _robotCommands.Clear();
        }

        public IEnumerable<IRobotCommand> GetAll()
        {
            return _robotCommands as IEnumerable<IRobotCommand>;
        }
    }
}
