using System.Collections.Generic;

namespace JudgeSystem
{
    public class ZoneManager
    {
        private readonly Dictionary<Identity, Zone> _zones = new();
            
        private struct Identity
        {
            public Camp Camp;
            public ushort Id;
        }
        
        public virtual Zone this[Camp camp, ushort id]
        {
            get => _zones[new Identity { Camp = camp, Id = id }];
            protected set => _zones[new Identity { Camp = camp, Id = id }] = value;
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
    }
}