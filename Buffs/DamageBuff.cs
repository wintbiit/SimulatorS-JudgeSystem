using System;

namespace JudgeSystem.Buffs
{
    public class DamageBuff: IDurationBuff
    {
        public float DamageMultiplier { get; private set; }
        public int Duration { get; private set; }
        public int Elapsed { get; set; }
        
        public DamageBuff(int duration, float damageMultiplier)
        {
            if (damageMultiplier <= 0)
            {
                throw new System.ArgumentException("Damage multiplier must be greater than 0");
            }
            DamageMultiplier = damageMultiplier;
            Duration = duration;
        }

        public IBuff Add(IBuff other)
        {
            var buff = (DamageBuff) other;
            DamageMultiplier = Math.Max(DamageMultiplier, buff.DamageMultiplier);
            Duration += buff.Duration;
            return this;
        }
    }
}