using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboInfra
{
    public interface ILogger
    {
        void LogInfo(string message);

        void LogWarn(string message);

        void LogException(string message);
    }
}
