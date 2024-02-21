using System;
using System.Collections.Concurrent;
using Event;
using JudgeSystem.Event;

namespace JudgeSystem
{
    public interface IBuff
    {
        
    }

    public interface IDurationBuff : IBuff
    {
        public int Duration { get; }
        public int Elapsed { get; set; }
        public IBuff Add(IBuff other);
    }

    public static class BuffUtils
    {
        public static bool Tick(this IDurationBuff buff)
        {
            buff.Elapsed++;
            return buff.Elapsed >= buff.Duration;
        }
    }

    public class BuffContainer : ConcurrentDictionary<Type, IBuff>
    {
        public BuffContainer()
        {
            EventManager.InjectAll(this);
        }
        
        [EventSubscriber]
        public void OnTick(ref TickEvent evt)
        {
            foreach (var buff in Values)
            {
                if (buff is IDurationBuff durationBuff)
                {
                    if (durationBuff.Tick())
                    {
                        TryRemove(buff.GetType(), out _);
                    }
                }
            }
        }
        
        public void Add<T>(T buff) where T: IBuff
        {
            if (TryGetValue(buff.GetType(), out var existing))
            {
                if (existing is IDurationBuff durationBuff)
                {
                    this[buff.GetType()] = durationBuff.Add(buff);
                }
            }
            else
            {
                TryAdd(buff.GetType(), buff);
            }
        }
        
        public void Remove<T>() where T: IBuff
        {
            TryRemove(typeof(T), out _);
        }
        
        public T Get<T>() where T: IBuff
        {
            if (TryGetValue(typeof(T), out var buff))
            {
                return (T) buff;
            }
            return default;
        }
        
        public bool Has<T>() where T: IBuff
        {
            return ContainsKey(typeof(T));
        }
        
        public bool TryGet<T>(out T buff) where T: IBuff
        {
            if (TryGetValue(typeof(T), out var b))
            {
                buff = (T) b;
                return true;
            }
            buff = default;
            return false;
        }
    }
}