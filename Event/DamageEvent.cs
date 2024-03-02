using Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem.Event
{
    public class DamageEvent
    {
        public IIdentityHolder Attacker;
        public IIdentityHolder Victim;
        public float Damage;
    }
}