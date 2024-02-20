using System;

namespace JudgeSystem.Buffs
{
    public class DamageBuff: DurationBuff<DamageBuff>
    {
        public float DamageMultiplier { get; private set; }
        
        public DamageBuff(float duration, float damageMultiplier): base(duration)
        {
            if (damageMultiplier <= 0)
            {
                throw new System.ArgumentException("Damage multiplier must be greater than 0");
            }
            DamageMultiplier = damageMultiplier;
        }

        public override DamageBuff Add(DamageBuff buff)
        {
            DamageMultiplier = Math.Max(DamageMultiplier, buff.DamageMultiplier);
            return base.Add(buff);
        }
    }
}