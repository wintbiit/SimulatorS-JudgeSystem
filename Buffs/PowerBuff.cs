namespace JudgeSystem.Buffs
{
    public class PowerBuff: DurationBuff<PowerBuff>
    {
        public float PowerMultiplier { get; }
        
        public PowerBuff(float duration, float powerMultiplier): base(duration)
        {
            PowerMultiplier = powerMultiplier;
        }
    }
}