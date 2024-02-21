namespace JudgeSystem.Interfaces
{
    public interface IBuffHolder: IIdentityHolder
    {
        public BuffContainer Buffs { get; }
    }
}