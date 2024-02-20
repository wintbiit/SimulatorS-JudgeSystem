using System;

namespace JudgeSystem.Buffs
{
    public class CoolDownBuff: DurationBuff<CoolDownBuff>
    {
        public float CoolDownMultiplier { get; private set; }
        
        public CoolDownBuff(float duration, float coolDownMultiplier): base(duration)
        {
            CoolDownMultiplier = coolDownMultiplier;
        }

        public override CoolDownBuff Add(CoolDownBuff buff)
        {
            CoolDownMultiplier = Math.Max(CoolDownMultiplier, buff.CoolDownMultiplier);
            return base.Add(buff);
        }
    }
}