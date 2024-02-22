using System;
using System.Collections.Concurrent;
using JudgeSystem.Interfaces;

namespace JudgeSystem
{
    public class BuildingManager
    {
        private readonly ConcurrentDictionary<Identity, Building> _buildings = new();
        private JudgeSystem _judgeSystem;

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
            building.JudgeSystem = _judgeSystem;
            _buildings[building.Identity()] = building;
        }
        
        public BuildingManager(JudgeSystem judgeSystem)
        {
            _judgeSystem = judgeSystem;
        }
    }
}

