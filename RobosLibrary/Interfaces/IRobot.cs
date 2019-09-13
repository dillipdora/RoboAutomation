using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobosLibrary
{
    public interface IRobot
    {
        void Move(double distance);
        void Turn(double angle);
        void Beep();
    }
}
