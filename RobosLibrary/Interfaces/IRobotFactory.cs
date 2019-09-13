using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobosLibrary
{
    public interface IRobotFactory
    {
        IEnumerable<IRobot> GetRegisteredRobots();
    }
}
