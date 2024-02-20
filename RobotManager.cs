using System.Collections.Concurrent;

namespace JudgeSystem
{
    public class RobotManager: Entity
    {
        private readonly ConcurrentDictionary<Identity, Robot> _robots = new();
        
        public Robot this[Camp camp, ushort id]
        {
            get => _robots[new Identity(camp, id)];
            protected set => _robots[new Identity(camp, id)] = value;
        }
        
        public void Add(Robot robot)
        {
            _robots[new Identity(robot.Camp, robot.Id)] = robot;
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
    }
}