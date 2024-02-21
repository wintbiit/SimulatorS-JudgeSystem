using Event;
using JudgeSystem.Event;

namespace JudgeSystem._2024uc
{
    public class Economy2024UC: Economy
    {
        public Economy2024UC(MatchConfig matchConfig) : base(matchConfig)
        {
        }

        [EventSubscriber]
        public void OnTick(ref TickEvent evt)
        {
            
        }

        [EventSubscriber]
        public void OnStart(ref GameStartEvent evt)
        {
            
        }

        [EventSubscriber]
        public void OnEnd(ref GameOverEvent evt)
        {
            
        }
    }
}