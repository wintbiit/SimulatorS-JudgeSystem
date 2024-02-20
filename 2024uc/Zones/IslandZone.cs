using JudgeSystem._2024uc.Robot;
using JudgeSystem.Buffs;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Zone
{
    /// <summary>
    /// 资源岛增益点
    /// <remarks>5.3.2.6</remarks>
    /// </summary>
    public class IslandZone: SeizableZone
    {
        public const ushort ID = 0x00;
        
        public IslandZone() : base(Camp.Judge, ID)
        {
        }

        private static readonly DefenceBuff DefenceBuff = new (60f, 0.75f);
        public override void OnOccupy(IRobot occupier)
        {
            if (occupier is not Engineer) return;
            if (JudgeSystem.Time < 60f) return;
            base.OnOccupy(occupier);
            
            occupier.AddBuff(DefenceBuff);
        }
        
        public override void OnRelease(IRobot occupier)
        {
            if (occupier is not Engineer) return;
            base.OnRelease(occupier);
            
            occupier.RemoveBuff<DefenceBuff>();
        }
    }
}