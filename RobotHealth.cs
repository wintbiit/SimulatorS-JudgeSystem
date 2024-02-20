using System.Collections.Generic;
using Event;
using JudgeSystem.Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem
{
    public abstract partial class Robot
    {
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
        
        private readonly ReviveEvent _reviveEvent = new();
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
        
        private readonly Dictionary<IIdentityHolder, float> _damageRecord = new();
        private readonly KillEvent _killEvent = new();
        public void TakeDamage(IShooter shooter)
        {
            if (shooter.Camp == Camp && !JudgeSystem.MatchConfig.FriendlyFire) return;
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
    }
}