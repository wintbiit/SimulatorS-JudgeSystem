using System;

namespace JudgeSystem.Buffs
{
    public class CoolDownBuff: IDurationBuff
    {
        public float CoolDownMultiplier { get; private set; }
        public int Duration { get; private set; }
        public int Elapsed { get; set; }
        
        public CoolDownBuff(int duration, float coolDownMultiplier)
        {
            CoolDownMultiplier = coolDownMultiplier;
            Duration = duration;
        }

        public IBuff Add(IBuff ibuff)
        {
            var buff = (CoolDownBuff) ibuff;
            CoolDownMultiplier = Math.Max(CoolDownMultiplier, buff.CoolDownMultiplier);
            Duration = buff.Duration + Duration;
            return this;
        }
    }
}