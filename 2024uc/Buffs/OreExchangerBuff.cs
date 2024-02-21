namespace JudgeSystem._2024uc.Buffs
{
    public abstract class OreExchangerBuff: IBuff
    {
        public abstract float OreValueMultiplier { get; }
    }
    
    public class OreExchangerBuff1: OreExchangerBuff
    {
        public override float OreValueMultiplier => 1f;
    }
    
    public class OreExchangerBuff2: OreExchangerBuff
    {
        public override float OreValueMultiplier => 1f;
    }
    
    public class OreExchangerBuff3: OreExchangerBuff
    {
        public override float OreValueMultiplier => 1.4f;
    }
    
    public class OreExchangerBuff4: OreExchangerBuff
    {
        public override float OreValueMultiplier => 2.0f;
    }
}