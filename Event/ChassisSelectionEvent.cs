using JudgeSystem.Interfaces;

namespace JudgeSystem.Event
{
    public class ChassisSelectionEvent: IdentityHolderEvent<ChassisSelectionEvent>
    {
        public int Chassis;

        public void ReadFrom(IChassisHolder robot)
        {
            base.ReadFrom(robot);
            Chassis = robot.Chassis;
        }
    }
}