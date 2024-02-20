using JudgeSystem._2024uc.Buffs;
using JudgeSystem.Buffs;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Zones
{
    /// <summary>
    /// 补血点
    /// <remarks>5.3.2.7</remarks>
    /// </summary>
    public class HealZone: Zone
    {
        public const ushort ID = 0x01;
        public HealZone(Camp camp) : base(camp, ID)
        {
        }
        
        private static readonly HealZoneBuff HealZoneBuff = new();
        public override void OnEnterZone(IRobot occupier)
        {
            if (occupier.Camp != Camp) return;
            base.OnEnterZone(occupier);
            var healMultiplier = 0.1f;
            if (JudgeSystem.Time > 240f && occupier.HasBuff<OutCombatBuff>())
            {
                healMultiplier = 0.25f;
                var powerBuff = new PowerBuff(float.MaxValue, 2f);
                occupier.AddBuff(powerBuff);
            }
            var healBuff = new HealBuff(float.MaxValue, healMultiplier);
            
            occupier.AddBuff(healBuff);
            occupier.AddBuff(HealZoneBuff);
        }
        
        public override void OnExitZone(IRobot occupier)
        {
            base.OnExitZone(occupier);
            occupier.RemoveBuff<HealBuff>();
            occupier.RemoveBuff<PowerBuff>();
            occupier.RemoveBuff<HealZoneBuff>();
            
            occupier.AddBuff(new PowerBuff(4f, 2f));
        }
    }
}