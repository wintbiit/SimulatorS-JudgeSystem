using Event;
using JudgeSystem._2024uc.Buildings.Interfaces;
using JudgeSystem.Event;

namespace JudgeSystem._2024uc.Events
{
    public class PowerRuneStartEvent
    {
        public PowerRuneType Type;
        
        public void ReadFrom(IPowerRuneController powerRuneController)
        {
            Type = powerRuneController.Type;
        }
    }
    
    public class PowerRuneEndEvent
    {
        public PowerRuneType Type;
        
        public void ReadFrom(IPowerRuneController powerRuneController)
        {
            Type = powerRuneController.Type;
        }
    }
    
    public class PowerRuneActivateEvent: IdentityHolderEvent
    {
        public PowerRuneType Type;
        public int RingCount;

        public void ReadFrom(IPowerRuneController powerRuneController)
        {
            base.ReadFrom(powerRuneController);
            Type = powerRuneController.Type;
            RingCount = powerRuneController.LastRingCount;
        }
    }
    
}