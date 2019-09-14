
using RoboAutomation.Services;

namespace RoboAutomation.Interfaces
{
    public interface IRobotCommand
    {
        int RobotIndex { get; set; }

        string CommandName { get; set; }

        double Value { get; set; }
    }
}
