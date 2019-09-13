using RobosLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RoboAutomation.Services
{
    public class RobotRepository
    {
        public List<string> Commands { get; set; }
        public List<IRobot> Robots { get; set; }

        public readonly static RobotRepository Instance = new RobotRepository();

        private RobotRepository()
        {
            Commands = new List<string>();
            Robots = new List<IRobot>();
        }

        public IRobot Find(int index)
        {
            return Robots.ElementAt(index);
        }

        internal void RegisterRobot(IEnumerable<IRobot> robots )
        {
            Robots.AddRange(robots);
            
            //find name of command that each robot support
            var anyRobot = robots.First();
            var methodInfos = typeof(IRobot).GetMethods();
            foreach(var methodInfo in methodInfos)
            {
                Commands.Add(methodInfo.Name);
            }
        }
    }
}
