namespace JudgeSystem.Interfaces
{
    public interface IIdentityHolder
    {
        Camp Camp { get; }
        ushort Id { get; }
    }

    public static class IdentityHelper
    {
        public static Identity Identity(this IIdentityHolder holder)
        {
            return new Identity(holder.Camp, holder.Id);
        }
    }
}