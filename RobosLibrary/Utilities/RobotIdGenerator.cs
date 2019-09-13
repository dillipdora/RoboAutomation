using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobosLibrary.Utilities
{
    internal static class RobotIdGenerator
    {
        private static int CurrentId { get; set; } = 0;

        public static int GiveNextId()
        {
            return CurrentId++;
        }
    }
}
