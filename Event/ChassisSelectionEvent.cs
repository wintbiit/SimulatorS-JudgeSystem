using JudgeSystem.Interfaces;

namespace JudgeSystem.Event
{
    public class ChassisSelectionEvent: IdentityHolderEvent
    {
        public int Chassis;

        public void ReadFrom(IChassisHolder robot)
        {
            base.ReadFrom(robot);
            Chassis = robot.Chassis;
        }
    }
}