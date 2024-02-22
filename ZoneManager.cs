using System;
using System.Collections.Generic;
using JudgeSystem.Interfaces;

namespace JudgeSystem
{
    public class ZoneManager: Entity
    {
        private readonly Dictionary<Identity, Zone> _zones = new();
        private JudgeSystem _judgeSystem;
        
        public virtual Zone this[Camp camp, ushort id]
        {
            get
            {
                if (_zones.TryGetValue(new Identity(camp, id), out var robot))
                {
                    return robot;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Zone {camp} {id} not found");
                }
            }
            protected set => _zones[new Identity(camp, id)] = value;
        }
        
        public void Add(Zone zone)
        {
            zone.JudgeSystem = _judgeSystem;
            _zones[zone.Identity()] = zone;
        }
        
        public virtual void ForEach(System.Action<Zone> action)
        {
            foreach (var zone in _zones.Values)
            {
                action(zone);
            }
        }
        
        public virtual void ForEach(System.Action<Zone, Camp, ushort> action)
        {
            foreach (var zone in _zones)
            {
                action(zone.Value, zone.Key.Camp, zone.Key.Id);
            }
        }
        
        public ZoneManager(JudgeSystem judgeSystem)
        {
            _judgeSystem = judgeSystem;
        }
    }
}