using Newtonsoft.Json;
using RobosLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Threading;

namespace RobosLibrary
{
    internal class Robot : IRobot
    {
        public string Name { get; set; }

        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public double StartPosition { get; set; }

        [JsonIgnore]
        public double EndPosition { get; set; }

        public Robot(string name)
        {
            Id = RobotIdGenerator.GiveNextId();
            Name = name;
            StartPosition = 0;
            EndPosition = 0;
        }

        #region IRobot implementation
        public void Beep()
        {
            System.Media.SystemSounds.Beep.Play();
            Thread.CurrentThread.Join(1000);
        }

        public void Move(double distance)
        {
            EndPosition += distance;
            Thread.CurrentThread.Join(1000);
        }

        public void Turn(double angle)
        {
            //todo: add some logic here
            Thread.CurrentThread.Join(1000);
        }
        #endregion
    }
}
