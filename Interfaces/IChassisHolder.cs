namespace JudgeSystem.Interfaces
{
    public interface IChassisHolder: IHealthEntity
    {
        public int Chassis { get; set; }
        public int MaxPower { get; }
        public int ChassisMaxPower { get; }
    }
}