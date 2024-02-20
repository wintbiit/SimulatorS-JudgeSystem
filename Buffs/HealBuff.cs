namespace JudgeSystem.Buffs
{
    public class HealBuff: DurationBuff<HealBuff>
    {
        public float HealMultiplier { get; }
        
        public HealBuff(float duration, float healMultiplier): base(duration)
        {
            HealMultiplier = healMultiplier;
        }
    }
}