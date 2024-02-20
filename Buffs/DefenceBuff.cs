using System;

namespace JudgeSystem.Buffs
{
    public class DefenceBuff: DurationBuff<DefenceBuff>
    {
        public float DefenceMultiplier { get; private set;  }
        
        public DefenceBuff(float duration, float defenceMultiplier): base(duration)
        {
            DefenceMultiplier = defenceMultiplier;
        }

        public override DefenceBuff Add(DefenceBuff buff)
        {
            if ((DefenceMultiplier >= 0 && buff.DefenceMultiplier >= 0) || (DefenceMultiplier <= 0 && buff.DefenceMultiplier <= 0))
            {
                DefenceMultiplier = Math.Max(DefenceMultiplier, buff.DefenceMultiplier);
            }
            else
            {
                DefenceMultiplier += buff.DefenceMultiplier;
            }
            return base.Add(buff);
        }
    }
}