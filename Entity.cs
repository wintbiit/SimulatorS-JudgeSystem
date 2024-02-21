using Event;

namespace JudgeSystem
{
    public abstract class Entity
    {
        protected Entity()
        {
            EventManager.InjectAll(this);
        }
    }
}