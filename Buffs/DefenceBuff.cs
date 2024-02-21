using System;

namespace JudgeSystem.Buffs
{
    public class DefenceBuff: IDurationBuff
    {
        public float DefenceMultiplier { get; private set;  }
        public int Duration { get; private set; }
        public int Elapsed { get; set; }
        
        public DefenceBuff(int duration, float defenceMultiplier)
        {
            DefenceMultiplier = defenceMultiplier;
            Duration = duration;
        }

        public IBuff Add(IBuff other)
        {
            var buff = (DefenceBuff) other;
            if ((DefenceMultiplier >= 0 && buff.DefenceMultiplier >= 0) || (DefenceMultiplier <= 0 && buff.DefenceMultiplier <= 0))
            {
                DefenceMultiplier = Math.Max(DefenceMultiplier, buff.DefenceMultiplier);
            }
            else
            {
                DefenceMultiplier += buff.DefenceMultiplier;
            }
            
            Duration += buff.Duration;
            return this;
        }
    }
}