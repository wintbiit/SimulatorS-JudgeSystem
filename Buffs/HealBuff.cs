using System;

namespace JudgeSystem.Buffs
{
    public class HealBuff: IDurationBuff
    {
        public float HealMultiplier { get; private set; }
        public int Duration { get; private set; }
        public int Elapsed { get; set; }
        
        public HealBuff(int duration, float healMultiplier)
        {
            HealMultiplier = healMultiplier;
            Duration = duration;
        }

        public IBuff Add(IBuff other)
        {
            var buff = (HealBuff) other;
            Duration += buff.Duration;
            HealMultiplier = Math.Max(HealMultiplier, buff.HealMultiplier);
            return this;
        }
    }
}