using Event;
using JudgeSystem._2024uc.Robots.Interfaces;
using JudgeSystem.Buffs;
using JudgeSystem.Event;

namespace JudgeSystem._2024uc.Robots
{
    public partial class AutoSentinel: IAutoSentinelController
    {
        private static readonly RemoteHealEvent RemoteHealEvent = new();
        public bool TryRemoteHeal()
        {
            RemoteHealEvent.ReadFrom(this);
            RemoteHealEvent.Publish();
            if (RemoteHealEvent.IsCancelled) return false;
            
            Health += (int)(0.6 * MaxHealth);
            return true;
        }

        private HealBuff _healBuff;
        private CoolDownBuff _coolDownBuff;
        private static readonly OutCombatBuff OutCombatBuff = new();
        [EventSubscriber]
        public void OnTick(ref TickEvent evt)
        {
            if (Buffs.TryGet(out _healBuff))
            {
                Health += (int)(_healBuff.HealMultiplier * MaxHealth);
            }
            
            if (Buffs.TryGet(out _coolDownBuff))
            {
                var heat =  Heat - (uint) (DeltaHeat * _coolDownBuff.CoolDownMultiplier); 
                Heat = heat > 0 ? heat : 0;
            }

            if (evt.Time - _lastShootTick > Performance.Predefined.OutCombatInterval
                && evt.Time - _lastDamageTick > Performance.Predefined.OutCombatInterval)
            {
                Buffs.Add(OutCombatBuff);
            }
            else
            {
                Buffs.Remove<OutCombatBuff>();
            }
        }
    }
}