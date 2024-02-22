namespace JudgeSystem.Buffs
{
    public class InvincibleBuff: IDurationBuff
    {
        public int Duration { get; private set; }
        public int Elapsed { get; set; }
        public IBuff Add(IBuff other)
        {
            var buff = (InvincibleBuff)other;
            Duration += buff.Duration;
            return this;
        }
    }
}