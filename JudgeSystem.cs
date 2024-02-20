using Autofac;

namespace JudgeSystem
{
    public abstract class JudgeSystem
    {
        public float Time { get; protected set; }
        public float MaxTime { get; protected set; }
        
        protected IContainer Container { get; private set; }
        
        public Economy Economy { get; protected set; }
        public RobotManager Robots { get; protected set; }
        
        public bool FriendlyFire { get; protected set; }

        protected JudgeSystem(float time, Economy economy, RobotManager robots)
        {
            Time = time;

            var builder = new ContainerBuilder();
            builder.RegisterInstance(economy).As<Economy>();
            builder.RegisterInstance(robots).As<RobotManager>();

            Container = builder.Build();
        }
        
        public float Tick(float deltaTime)
        {
            if (Time + deltaTime > MaxTime)
            {
                deltaTime = MaxTime - Time;
            }
            
            Time += deltaTime;
            
            return deltaTime;
        }
    }
}