using JudgeSystem._2024uc.Buffs;
using JudgeSystem._2024uc.Robots;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Zones
{
    /// <summary>
    /// 狙击点增益
    /// <remarks>5.3.2.9</remarks>
    /// </summary>
    public class SniperZone: SeizableZone
    {
        public const ushort ID = 0x04;
        public SniperZone(Camp camp) : base(camp, ID)
        {
        }

        private static readonly SniperBuff SniperBuff = new();
        public override void OnOccupy(IRobot occupier)
        {
            if (occupier.Camp != Camp) return;
            if (occupier is not Hero) return;
            base.OnOccupy(occupier);
            
            occupier.AddBuff(SniperBuff);
        }
        
        public override void OnRelease(IRobot occupier)
        {
            if (occupier.Camp != Camp) return;
            if (occupier is not Hero) return;
            base.OnRelease(occupier);

            occupier.RemoveBuff<SniperBuff>();
        }
    }
}