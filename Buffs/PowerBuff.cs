using System;

namespace JudgeSystem.Buffs
{
    public class PowerBuff: IDurationBuff
    {
        public float PowerMultiplier { get; private set; }
        public int Duration { get; private set; }
        public int Elapsed { get; set; }
        
        public PowerBuff(int duration, float powerMultiplier)
        {
            PowerMultiplier = powerMultiplier;
            Duration = duration;
        }

        
        public IBuff Add(IBuff other)
        {
            var buff = (PowerBuff) other;
            PowerMultiplier = Math.Max(PowerMultiplier, buff.PowerMultiplier);
            Duration += buff.Duration;
            
            return this;
        }
    }
}