using System;
using System.Collections.Generic;
using System.Linq;
using Event;
using JudgeSystem._2024uc.Buffs;
using JudgeSystem._2024uc.Events;
using JudgeSystem.Buffs;
using JudgeSystem.Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc
{
    public class Economy2024UC: Economy
    {
        public Economy2024UC(MatchConfig matchConfig) : base(matchConfig)
        {
            for (var i = 0; i < 5; i++)
            {
                _addCoin50[i] = 60 * (i + 1) + matchConfig.WaitTime;
            }
            
            _addCoin150 = 360 + matchConfig.WaitTime;
        }

        private readonly int[] _addCoin50 = new int[5];
        private readonly int _addCoin150;

        [EventSubscriber]
        public void OnTick(ref TickEvent evt)
        {
            if (_addCoin50.Contains(evt.Time))
            {
                IncreaseEconomy(50);
                Logs.I("Natural income: 50");
            } else if (evt.Time == _addCoin150)
            {
                IncreaseEconomy(150);
                Logs.I("Natural income: 150");
            }
        }

        [EventSubscriber]
        public void OnStart(ref GameStartEvent evt)
        {
            IncreaseEconomy(400 + MatchConfig.RedInitialEconomy);
        }

        [EventSubscriber]
        public void OnEnd(ref GameOverEvent evt)
        {
            
        }

        private record AmmoRecordKey(Camp Camp, Ammos Ammo);
        private readonly Dictionary<AmmoRecordKey, int> _ammoExchanged = new();
        [EventSubscriber(SubscriberPriority.Highest)]
        public void OnTryBuyAmmo(ref BuyAmmoEvent evt)
        {
            var robot = JudgeSystem.RobotManager[evt.Camp, evt.Id];

            if (!robot.Buffs.Has<HealZoneBuff>())
            {
                evt.Cancelled = true;
                return;
            }

            var ammo = (Ammos) evt.AmmoType;
            if (!_ammoExchanged.TryGetValue(new AmmoRecordKey(evt.Camp, ammo), out var exchanged))
            {
                exchanged = 0;
            }
            if (exchanged + evt.Count > Performance.Predefined.Economy.AmmoPrices[ammo].MaxExchange)
            {
                evt.Cancelled = true;
                return;
            }
            
            var price = GetPerAmmoCost(ammo, false) * evt.Count;
            if (!TryCost(robot.Camp, price))
            {
                evt.Cancelled = true;
            }
            
            _ammoExchanged[new AmmoRecordKey(evt.Camp, ammo)] = exchanged + evt.Count;
        }
        public int GetPerAmmoCost(Ammos ammo, bool remote)
        {
            if (!remote)
            {
                return Performance.Predefined.Economy.AmmoPrices[ammo].Local;
            }
            else
            {
                return Performance.Predefined.Economy.AmmoPrices[ammo].Remote;
            }
        }
        
        [EventSubscriber(SubscriberPriority.Highest)]
        public void OnTryRemoteBuyAmmo(ref RemoteBuyAmmoEvent evt)
        {
            var robot = JudgeSystem.RobotManager[evt.Camp, evt.Id];

            if (!robot.Buffs.Has<HealZoneBuff>())
            {
                evt.Cancelled = true;
                return;
            }

            var ammo = (Ammos) evt.AmmoType;
            if (!_ammoExchanged.TryGetValue(new AmmoRecordKey(evt.Camp, ammo), out var exchanged))
            {
                exchanged = 0;
            }
            if (exchanged + evt.Count > Performance.Predefined.Economy.AmmoPrices[ammo].MaxExchange)
            {
                evt.Cancelled = true;
                return;
            }
            
            var price = GetPerAmmoCost(ammo, true) * evt.Count;
            if (!TryCost(robot.Camp, price))
            {
                evt.Cancelled = true;
                return;
            }
            
            _ammoExchanged[new AmmoRecordKey(evt.Camp, ammo)] = exchanged + evt.Count;
        }

        [EventSubscriber(SubscriberPriority.Highest)]
        public void OnTryBuyRevive(ref RemoteReviveEvent evt)
        {
            var robot = JudgeSystem.RobotManager[evt.Camp, evt.Id];
            var level = 0;
            if (robot is IExperienceHolder holder)
            {
                level = holder.Level;
            }
            var price = GetBuyReviveCost(level);

            if (!TryCost(robot.Camp, price))
            {
                evt.Cancelled = true;
            }
        }
        public int GetBuyReviveCost(int level)
        {
            return (int) Math.Ceiling(420 - (JudgeSystem.Time - MatchConfig.WaitTime) / 60d)
                   * 80 + 20 * level;
        }
        
        private static readonly OreExchangerBuff1 OreExchangerBuff1 = new();
        private static readonly OreExchangerBuff2 OreExchangerBuff2 = new();
        private static readonly OreExchangerBuff3 OreExchangerBuff3 = new();
        private static readonly OreExchangerBuff4 OreExchangerBuff4 = new();
        [EventSubscriber]
        public void OnOreExchange(ref ExchangeOreEvent evt)
        {
            var price = Performance.Predefined.OrePrices[evt.Grade][evt.Ore];

            var multiplier = 1f;
            if (JudgeSystem.RobotManager[evt.Camp, evt.Id].Buffs.TryGet<OreExchangerBuff1>(out var buff))
            {
                multiplier = buff.OreValueMultiplier;
            } else if (JudgeSystem.RobotManager[evt.Camp, evt.Id].Buffs.TryGet<OreExchangerBuff2>(out var buff2))
            {
                multiplier = buff2.OreValueMultiplier;
            } else if (JudgeSystem.RobotManager[evt.Camp, evt.Id].Buffs.TryGet<OreExchangerBuff3>(out var buff3))
            {
                multiplier = buff3.OreValueMultiplier;
            } else if (JudgeSystem.RobotManager[evt.Camp, evt.Id].Buffs.TryGet<OreExchangerBuff4>(out var buff4))
            {
                multiplier = buff4.OreValueMultiplier;
            }

            switch (evt.HoldTime)
            {
                case >= 0 and < 15: multiplier *= 1f; break;
                case >= 15 and < 65: multiplier *= (evt.HoldTime - 15) * 0.02f; break;
                case >= 65: multiplier *= 0; break;
            }
            
            price = (int) (price * multiplier);
            
            IncreaseEconomy(evt.Camp, price);

            switch (GetIncome(evt.Camp))
            {
                case >= 1600: JudgeSystem.RobotManager[evt.Camp, evt.Id].Buffs.Add(OreExchangerBuff4); break;
                case >= 1000 and < 1600: JudgeSystem.RobotManager[evt.Camp, evt.Id].Buffs.Add(OreExchangerBuff3); break;
                case >= 750 and < 1000: JudgeSystem.RobotManager[evt.Camp, evt.Id].Buffs.Add(OreExchangerBuff2); break;
                case >= 625 and < 750: JudgeSystem.RobotManager[evt.Camp, evt.Id].Buffs.Add(OreExchangerBuff1); break;
            }
            
            Logs.I($"Ore exchange: {price}");
        }

        private readonly Dictionary<Camp, int> _droneSummoned = new();
        [EventSubscriber(SubscriberPriority.Highest)]
        public void OnSummonDrone(ref DroneSummonEvent evt)
        {
            var price = GetSummonDroneCost();
            evt.Cost = price;
            
            if (!_droneSummoned.TryGetValue(evt.Camp, out var count))
            {
                count = 0;
            }
            
            if (count >= Performance.Predefined.MaxDroneSummon)
            {
                evt.Cancelled = true;
                return;
            }
            
            if (!TryCost(evt.Camp, price))
            {
                evt.Cancelled = true;
                return;
            }
            
            _droneSummoned[evt.Camp] = count + 1;
        }

        public int GetSummonDroneCost()
        {
            return (int)Math.Ceiling((JudgeSystem.Time - MatchConfig.WaitTime) / 25d) * 25;
        }

        [EventSubscriber(SubscriberPriority.Highest)]
        public void OnRemoteBuyHealth(ref RemoteHealEvent evt)
        {
            var robot = JudgeSystem.RobotManager[evt.Camp, evt.Id];
            if (robot is IBuffHolder holder && holder.Buffs.Has<OutCombatBuff>())
            {
                var price = GetRemoteBuyHealthCost();
                
                if (!TryCost(robot.Camp, price))
                {
                    evt.Cancelled = true;
                }
                
                return;
            }

            evt.Cancelled = true;
        }
        
        public int GetRemoteBuyHealthCost()
        {
            return (int)Math.Ceiling(420 - (JudgeSystem.Time - MatchConfig.WaitTime) / 60d) * 20 + 50;
        }
    }
}