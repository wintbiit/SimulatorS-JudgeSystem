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
            if (JudgeSystem.Time > 240f && occupier.Buffs.Has<OutCombatBuff>())
            {
                healMultiplier = 0.25f;
                var powerBuff = new PowerBuff(int.MaxValue, 2f);
                occupier.Buffs.Add(powerBuff);
            }
            var healBuff = new HealBuff(int.MaxValue, healMultiplier);
            
            occupier.Buffs.Add(healBuff);
            occupier.Buffs.Add(HealZoneBuff);
        }
        
        public override void OnExitZone(IRobot occupier)
        {
            base.OnExitZone(occupier);
            occupier.Buffs.Remove<HealBuff>();
            occupier.Buffs.Remove<PowerBuff>();
            occupier.Buffs.Remove<HealZoneBuff>();
            
            occupier.Buffs.Add(new PowerBuff(4, 2f));
        }
    }
}