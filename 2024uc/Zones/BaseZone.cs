using JudgeSystem.Buffs;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Zones
{
    /// <summary>
    /// 基地增益点
    /// <remarks>5.3.2.1</remarks>
    /// </summary>
    public class BaseZone: Zone
    {
        public const ushort ID = 0x02;
        public BaseZone(Camp camp) : base(camp, ID)
        {
        }

        private static readonly DefenceBuff DefenceBuff = new (float.MaxValue, 0.5f);
        public override void OnEnterZone(IRobot occupier)
        {
            if (occupier.Camp != Camp) return;
            base.OnEnterZone(occupier);
            switch (JudgeSystem.Time)
            {
                case > 120 and < 180:
                    occupier.AddBuff(new CoolDownBuff(float.MaxValue, 2f));
                    break;
                case > 180 and < 300:
                    occupier.AddBuff(new CoolDownBuff(float.MaxValue, 3f));
                    break;
                case > 300 and < 420:
                    occupier.AddBuff(new CoolDownBuff(float.MaxValue, 5f));
                    break;
            } 
            
            occupier.AddBuff(DefenceBuff);
        }
        
        public override void OnExitZone(IRobot occupier)
        {
            base.OnExitZone(occupier);
            
            occupier.RemoveBuff<DefenceBuff>();
            occupier.RemoveBuff<CoolDownBuff>();
        }
    }
}