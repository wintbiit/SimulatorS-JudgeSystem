using System;

namespace JudgeSystem
{
    public abstract class Buff: Entity
    {
        
    }
    public abstract class Buff<T>: Buff where T: Buff<T>
    {
        public virtual T Add(T buff)
        {
            return (T) this;
        }
    }
    
    public abstract class DurationBuff<T>: Buff<T> where T: DurationBuff<T>
    {
        public float Duration;
        public float ElapsedTime;
        public const float Tolerance = 0.01f;
        
        protected DurationBuff(float duration)
        {
            if (duration < 0)
            {
                throw new ArgumentException("Duration must be greater than or equal to 0");
            }
            Duration = duration;
        }
        
        public bool IsExpired => ElapsedTime > Duration + Tolerance;
        
        public virtual void Update(float deltaTime)
        {
            ElapsedTime += deltaTime;
        }
        
        public override T Add(T buff)
        {
            if (Duration <= 0 || buff.Duration <= 0)
            {
                Duration = Math.Max(Math.Max(Duration, buff.Duration), 0f);
            }
            else
            {
                Duration += buff.Duration;
            }
            return (T) this;
        }
    }
}