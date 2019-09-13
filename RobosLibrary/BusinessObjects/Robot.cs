using Newtonsoft.Json;
using RobosLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace RobosLibrary
{
    internal class Robot : IRobot
    {
        public string Name { get; set; }

        [JsonIgnore]
        public int Id { get; set; }

        public Robot(string name)
        {
            Id = RobotIdGenerator.GiveNextId();
            Name = name;
        }

        #region IRobot implementation
        public void Beep()
        {
            throw new NotImplementedException();
        }

        public void Move(double distance)
        {
            throw new NotImplementedException();
        }

        public void Turn(double angle)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
