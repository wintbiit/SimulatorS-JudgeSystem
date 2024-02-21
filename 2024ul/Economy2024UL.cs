using Event;
using JudgeSystem.Event;

namespace JudgeSystem._2024ul
{
    public class Economy2024UL: Economy
    {
        public Economy2024UL(MatchConfig matchConfig) : base(matchConfig)
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

        [EventSubscriber(SubscriberPriority.Highest)]
        public void OnTryBuyAmmo(ref BuyAmmoEvent evt)
        {
            
        }
        
        [EventSubscriber(SubscriberPriority.Highest)]
        public void OnTryRemoteBuyAmmo(ref RemoteBuyAmmoEvent evt)
        {
            
        }

        [EventSubscriber(SubscriberPriority.Highest)]
        public void OnTryBuyRevive(ref RemoteReviveEvent evt)
        {
            
        } 
    }
}