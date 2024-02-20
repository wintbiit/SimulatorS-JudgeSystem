using System.Collections.Concurrent;

namespace JudgeSystem
{
    public class BuildingManager
    {
        private readonly ConcurrentDictionary<Identity, Building> _buildings = new();

        public Building this[Camp camp, ushort id]
        {
            get => _buildings[new Identity(camp, id)];
            protected set => _buildings[new Identity(camp, id)] = value;
        }
        
        public void Add(Building building)
        {
            _buildings[new Identity(building.Camp, building.Id)] = building;
        }
    }
}

