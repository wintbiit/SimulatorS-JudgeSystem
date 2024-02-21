using Event;
using JudgeSystem._2024uc.Buildings.Interfaces;
using JudgeSystem.Event;

namespace JudgeSystem._2024uc.Events
{
    public class PowerRuneStartEvent: Event<PowerRuneStartEvent>
    {
        PowerRuneType Type;
        
        public void ReadFrom(IPowerRuneController powerRuneController)
        {
            Type = powerRuneController.Type;
        }
    }
    
    public class PowerRuneEndEvent: Event<PowerRuneEndEvent>
    {
        PowerRuneType Type;
        
        public void ReadFrom(IPowerRuneController powerRuneController)
        {
            Type = powerRuneController.Type;
        }
    }
    
    public class PowerRuneActivateEvent: IdentityHolderEvent<PowerRuneActivateEvent>
    {
        PowerRuneType Type;
        public int RingCount;

        public void ReadFrom(IPowerRuneController powerRuneController)
        {
            base.ReadFrom(powerRuneController);
            Type = powerRuneController.Type;
            RingCount = powerRuneController.LastRingCount;
        }
    }
    
}