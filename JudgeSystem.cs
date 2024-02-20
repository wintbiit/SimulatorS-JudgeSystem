namespace JudgeSystem
{
    public abstract class JudgeSystem
    {
        public float Time { get; protected set; } = 0;
        public abstract float MaxTime { get; }
        
        public bool FriendlyFire { get; protected set; }

        protected JudgeSystem()
        {
            
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