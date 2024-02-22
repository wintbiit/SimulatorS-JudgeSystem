using System;
using System.Collections.Concurrent;
using JudgeSystem.Interfaces;

namespace JudgeSystem
{
    public class RobotManager: Entity
    {
        private readonly ConcurrentDictionary<Identity, Robot> _robots = new();
        private JudgeSystem _judgeSystem;
        
        public Robot this[Camp camp, ushort id]
        {
            get
            {
                if (_robots.TryGetValue(new Identity(camp, id), out var robot))
                {
                    return robot;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Robot {camp} {id} not found");
                }
            }
            protected set => _robots[new Identity(camp, id)] = value;
        }

        public void Add(Robot robot)
        {
            robot.JudgeSystem = _judgeSystem;
            _robots[robot.Identity()] = robot;
        }
        
        public void ForEach(System.Action<Robot> action)
        {
            foreach (var robot in _robots.Values)
            {
                action(robot);
            }
        }
        
        public void ForEach(System.Action<Robot, Camp, ushort> action)
        {
            foreach (var robot in _robots)
            {
                action(robot.Value, robot.Key.Camp, robot.Key.Id);
            }
        }
        
        public RobotManager(JudgeSystem judgeSystem)
        {
            _judgeSystem = judgeSystem;
        }
    }
}