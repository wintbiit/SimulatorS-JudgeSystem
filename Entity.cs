namespace JudgeSystem
{
    public abstract class Entity
    {
        protected Entity()
        {
            PerformanceSystem.Inject(GetType());
        }
    }
}