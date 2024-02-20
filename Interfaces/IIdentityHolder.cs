namespace JudgeSystem.Interfaces
{
    public interface IIdentityHolder
    {
        Camp Camp { get; }
        ushort Id { get; }
    }
}