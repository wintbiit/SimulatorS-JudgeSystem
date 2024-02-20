namespace JudgeSystem
{
    public abstract class JudgeSystem: Entity
    {
        public float Time { get; protected set; } = 0;
        public abstract float MaxTime { get; }
        
        public MatchConfig MatchConfig { get; protected set; }
        public RobotManager RobotManager { get; } = new();
        public ZoneManager ZoneManager { get; } = new();
        public BuildingManager BuildingManager { get; } = new();
        
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