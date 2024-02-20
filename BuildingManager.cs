using System.Collections.Concurrent;

namespace JudgeSystem
{
    public class BuildingManager
    {
        private readonly ConcurrentDictionary<Identity, Building> _buildings = new();
        
        private struct Identity
        {
            public Camp Camp;
            public ushort Id;
        }

        public virtual Building this[Camp camp, ushort id]
        {
            get => _buildings[new Identity { Camp = camp, Id = id }];
            protected set => _buildings[new Identity { Camp = camp, Id = id }] = value;
        }
    }
}