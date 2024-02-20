using System.Collections.Concurrent;

namespace JudgeSystem
{
    public class RobotManager: Entity
    {
        private readonly ConcurrentDictionary<Identity, Robot> _robots = new();
        
        private struct Identity
        {
            public Camp Camp;
            public ushort Id;
        }
        
        public virtual Robot this[Camp camp, ushort id]
        {
            get => _robots[new Identity { Camp = camp, Id = id }];
            protected set => _robots[new Identity { Camp = camp, Id = id }] = value;
        }
        
        public virtual void ForEach(System.Action<Robot> action)
        {
            foreach (var robot in _robots.Values)
            {
                action(robot);
            }
        }
        
        public virtual void ForEach(System.Action<Robot, Camp, ushort> action)
        {
            foreach (var robot in _robots)
            {
                action(robot.Value, robot.Key.Camp, robot.Key.Id);
            }
        }
    }
}