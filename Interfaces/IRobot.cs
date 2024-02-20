namespace JudgeSystem.Interfaces
{
    public interface IRobot: IHealthEntity, IBuffHolder
    {
        
    }
    
    public static class RobotUtils
    {
        public static bool IsRobot(this IIdentityHolder identityHolder)
        {
            return identityHolder is IRobot;
        }
    }
}