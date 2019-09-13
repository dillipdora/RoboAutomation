using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobosLibrary.Factories
{
    [Export(typeof(IRobotFactory))]
    internal class RobotFactory : IRobotFactory
    {
        public List<Robot> Robots { get; private set; }

        private const string _repoFile = "robots.txt";

        public RobotFactory()
        {
            //read robots.txt file and initialize Robots to give 
            //user the option to define robot list.
            string filePath = Path.Combine(Environment.CurrentDirectory, _repoFile);
            string repoData = File.ReadAllText(filePath);
            Robots = JsonConvert.DeserializeObject<List<Robot>>(repoData);
        }

        public IEnumerable<IRobot> GetRegisteredRobots()
        {
            return (Robots as IEnumerable<IRobot>);
        }
    }
}
