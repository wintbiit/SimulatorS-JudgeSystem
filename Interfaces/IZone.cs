namespace JudgeSystem.Interfaces
{
    public interface IZone: IIdentityHolder
    {
        
    }
    
    public static class ZoneUtils
    {
        public static bool IsZone(this IIdentityHolder identityHolder)
        {
            return identityHolder is IZone;
        }
    }
}