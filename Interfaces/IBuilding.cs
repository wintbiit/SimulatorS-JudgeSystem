namespace JudgeSystem.Interfaces
{
    public interface IBuilding: IIdentityHolder
    {
        
    }

    public static class BuildingUtils
    {
        public static bool IsBuilding(this IIdentityHolder identityHolder)
        {
            return identityHolder is IBuilding;
        }
    }
}