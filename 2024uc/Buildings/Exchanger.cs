namespace JudgeSystem._2024uc.Buildings
{
    public partial class Exchanger: Building
    {
        public const ushort ID = 0x02;
        
        public Exchanger(Camp camp): base(camp, ID)
        {
        }
    }
}