using System.Collections.Generic;
using Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem.Event
{
    public class KillEvent: Event<KillEvent>
    {
        public IIdentityHolder Killer;
        public IIdentityHolder Victim;
        public Dictionary<IIdentityHolder, float> DamageRecords;
    }
}