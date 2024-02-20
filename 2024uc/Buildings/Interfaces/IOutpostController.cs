using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Buildings.Interfaces
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