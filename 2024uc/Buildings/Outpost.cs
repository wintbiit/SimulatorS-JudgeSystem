using System;
using Event;
using JudgeSystem._2024uc.Buildings.Interfaces;
using JudgeSystem.Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Buildings
{
    public partial class Outpost: Building
    {
        public const ushort ID = 0x01;
        
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

        public void TakeDamage(IShooter shooter)
        {
            Health -= shooter.CalculateDamage(this);
        }

        public bool TryRevive()
        {
            JudgeSystemWarningEvent.RaiseNew("Outpost", "Trying to revive outpost. What are you doing?");
            throw new NotImplementedException();
        }

        public bool TryCoinRevive()
        {
            JudgeSystemWarningEvent.RaiseNew("Outpost", "Trying to coin revive outpost. What are you doing?");
            throw new NotImplementedException();
        }
        
        public Outpost(Camp camp, int maxHealth): base(camp, ID)
        {
            MaxHealth = maxHealth;
            _currentHealth = maxHealth;
            _armorStatus = OutpostArmorStatus.Normal;
        }
    }
}