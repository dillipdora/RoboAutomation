
using RoboAutomation.Services;

namespace RoboAutomation.Interfaces
{
    interface IRobotCommand
    {
        string CommandName { get; set; }
        void Execute(CommandPayload payload);
    }
}
