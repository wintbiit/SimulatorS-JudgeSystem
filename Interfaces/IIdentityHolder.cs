namespace JudgeSystem.Interfaces
{
    public interface IIdentityHolder
    {
        Camp Camp { get; }
        ushort Id { get; }
    }

    public static class IdentityHelper
    {
        public static string Identity(this IIdentityHolder holder)
        {
            return $"[{holder.Camp}:{holder.Id}]";
        }
    }
}