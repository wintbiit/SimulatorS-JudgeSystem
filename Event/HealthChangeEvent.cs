using Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem.Event
{
    public class HealthChangeEvent: IdentityHolderEvent
    {
        public float Health;
        
        public void ReadFrom(IHealthEntity entity)
        {
            base.ReadFrom(entity);
            Health = entity.Health;
        }
    }
}