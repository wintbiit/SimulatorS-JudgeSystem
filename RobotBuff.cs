using System;
using System.Collections.Concurrent;

namespace JudgeSystem
{
    public partial class Robot
    {
        private readonly ConcurrentDictionary<Type, Buff> _buffs = new();
        
        public bool TryGetBuff<T>(out T buff) where T : Buff<T>
        {
            if (_buffs.TryGetValue(typeof(T), out var value))
            {
                buff = (T) value;
                return true;
            }

            buff = default;
            return false;
        }

        public void AddBuff<T>(T buff, bool overwrite = false) where T : Buff<T>
        {
            if (!overwrite)
            {
                if (_buffs.TryGetValue(typeof(T), out var value))
                {
                    var newBuff = ((Buff<T>) value).Add(buff);
                    _buffs.TryUpdate(typeof(T), newBuff, value);
                }
                else
                {
                    _buffs.TryAdd(typeof(T), buff);
                
                }
            }
            else
            {
                _buffs.AddOrUpdate(typeof(T), buff, (_, _) => buff);
            }
        }

        public void RemoveBuff<T>() where T : Buff<T>
        {
            _buffs.TryRemove(typeof(T), out _);
        }

        public bool HasBuff<T>() where T : Buff<T>
        {
            return _buffs.ContainsKey(typeof(T));
        }
    }
}