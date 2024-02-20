using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Building.Interfaces
{
    public interface IOutpostController: IHealthEntity
    {
        public OutpostArmorStatus ArmorStatus { get; set; }
    }

    public enum OutpostArmorStatus
    {
        Normal,
        Slowed,
        Stopped
    }
}