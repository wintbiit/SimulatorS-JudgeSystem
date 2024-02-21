using Event;
using JudgeSystem._2024uc.Robots.Interfaces;
using JudgeSystem.Event;

namespace JudgeSystem._2024uc.Robots
{
    public partial class AutoSentinel: IAutoSentinelController
    {
        private static readonly RemoteHealEvent RemoteHealEvent = new();
        public bool TryRemoteHeal()
        {
            RemoteHealEvent.Reset();
            RemoteHealEvent.ReadFrom(this);
            RemoteHealEvent.Publish();
            if (RemoteHealEvent.Cancelled) return false;
            
            Health += (int)(0.6 * MaxHealth);
            return true;
        }
    }
}