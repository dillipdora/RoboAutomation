using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboAutomation.Interfaces
{
    public interface ICommandRepository
    {
        void Add(IRobotCommand cmd);

        void Clear();

        IEnumerable<IRobotCommand> GetAll();
    }
}
