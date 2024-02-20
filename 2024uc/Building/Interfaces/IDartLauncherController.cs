using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Building.Interfaces
{
    public interface IDartLauncherController: IShooter, IIdentityHolder
    {
        public DartLauncherGateStatus GateStatus { get; set; }
    }
    
    public enum DartLauncherGateStatus
    {
        Opened,
        Closed
    }
}