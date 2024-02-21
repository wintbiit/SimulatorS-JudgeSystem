using System;
using System.Collections.Concurrent;

namespace JudgeSystem
{
    public class BuildingManager
    {
        private readonly ConcurrentDictionary<Identity, Building> _buildings = new();

        public Building this[Camp camp, ushort id]
        {
            get
            {
                if (_buildings.TryGetValue(new Identity(camp, id), out var robot))
                {
                    return robot;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Zone {camp} {id} not found");
                }
            }
            protected set => _buildings[new Identity(camp, id)] = value;
        }
        
        public void Add(Building building)
        {
            _buildings[new Identity(building.Camp, building.Id)] = building;
        }
    }
}

