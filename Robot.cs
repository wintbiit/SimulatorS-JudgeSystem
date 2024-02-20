using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Event;
using JudgeSystem.Buffs;
using JudgeSystem.Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem
{
    public abstract class Robot: IRobot
    {
        protected JudgeSystem JudgeSystem;
        
        private int _currentHealth;
        private int _cachedHealth;
        
        private readonly HealthChangeEvent _healthChangeEvent = new();
        private readonly EntityDeathEvent _entityDeathEvent = new();
        
        public int Health
        {
            get => _currentHealth;
            set
            {
                _cachedHealth = _currentHealth;
                if (value < 0)
                {
                    _currentHealth = 0;
                }
                else if (value > MaxHealth)
                {
                    _currentHealth = MaxHealth;
                }
                else
                {
                    _currentHealth = value;
                }

                if (_cachedHealth == _currentHealth) return;
                _healthChangeEvent.Reset();
                _healthChangeEvent.ReadFrom(this);
                _healthChangeEvent.Publish();
                    
                if (_currentHealth <= 0)
                {
                    _entityDeathEvent.Reset();
                    _entityDeathEvent.ReadFrom(this);
                    _entityDeathEvent.Publish();
                }
            }
        }
        
        public int MaxHealth { get; }
        
        public Camp Camp { get; }
        public ushort Id { get; }

        private readonly Dictionary<IIdentityHolder, float> _damageRecord = new();
        private readonly KillEvent _killEvent = new();
        public void TakeDamage(IShooter shooter)
        {
            if (shooter.Camp == Camp && !JudgeSystem.FriendlyFire) return;
            var damage = shooter.CalculateDamage(this);
            
            Health -= damage;

            if (Health == 0)
            {
                _killEvent.Reset();
                _killEvent.Killer = shooter;
                _killEvent.Victim = this;
                _killEvent.Assistants = _damageRecord.Keys;
                _killEvent.Publish();
            }
            else
            {
                _damageRecord[shooter] = _damageRecord.TryGetValue(shooter, out var value) ? value + damage : damage;
            }
        }

        private ReviveEvent _reviveEvent = new();
        public bool TryRevive()
        {
            _reviveEvent.Reset();
            _reviveEvent.ReadFrom(this);
            _reviveEvent.Publish();
            return !_reviveEvent.Cancelled;
        }

        public bool TryCoinRevive()
        {
            _reviveEvent.Reset();
            _reviveEvent.ReadFrom(this);
            _reviveEvent.Remote = true;
            // TODO: Implement coin system
            _reviveEvent.Cost = 1;
            _reviveEvent.Publish();
            return !_reviveEvent.Cancelled;
        }

        private ConcurrentDictionary<Type, Buff> _buffs = new();
        
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

        private float _experience;
        public float Experience
        {
            get => _experience;
            set
            {
                _experience = value;
            }
        }

        public void AddExperience(float experience)
        {
            _experience += experience;
        }

        private uint _level;

        private readonly LevelUpEvent _levelUpEvent = new();
        public uint Level
        {
            get => _level;
            set
            {
                if (_level == value) return;
                _levelUpEvent.Reset();
                _levelUpEvent.ReadFrom(this);
                _levelUpEvent.Publish();
            }
        }

        public void OnTick()
        {
            if (HasBuff<HealBuff>())
            {
                _damageRecord.Clear();
            }
        }

        protected Robot(int maxHealth, Camp camp, ushort id)
        {
            MaxHealth = maxHealth;
            _currentHealth = maxHealth;
            Camp = camp;
            Id = id;
        }
    }
}