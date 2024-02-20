using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Building.Interfaces
{
    public interface IBaseController: IHealthEntity
    {
        public BaseArmorStatus ArmorStatus { get; set; }
    }

    public enum BaseArmorStatus
    {
        Opened,
        Closed
    }
}