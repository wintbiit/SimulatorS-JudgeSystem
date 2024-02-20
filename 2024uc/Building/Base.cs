using Event;
using JudgeSystem._2024uc.Building.Interfaces;
using JudgeSystem._2024uc.Event;
using JudgeSystem.Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Building
{
    public class Base: global::JudgeSystem.Building, IBaseController
    {
        public const ushort ID = 0x00;
        
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
            JudgeSystemWarningEvent.RaiseNew("Base", "Trying to revive base. What are you doing?");
            throw new System.NotImplementedException();
        }

        public bool TryCoinRevive()
        {
            JudgeSystemWarningEvent.RaiseNew("Base", "Trying to coin revive base. What are you doing?");
            throw new System.NotImplementedException();
        }

        public Base(Camp camp, int maxHealth) : base(camp, ID)
        {
            MaxHealth = maxHealth;
            _currentHealth = maxHealth;
            ArmorStatus = BaseArmorStatus.Closed;
        }

        private BaseArmorStatus _armorStatus;
        private readonly BaseArmorOpenEvent _baseArmorOpenEvent = new();
        public BaseArmorStatus ArmorStatus
        {
            get => _armorStatus;
            set
            {
                if (_armorStatus == value) return;
                _armorStatus = value;
                if (_armorStatus == BaseArmorStatus.Opened)
                {
                    _baseArmorOpenEvent.Reset();
                    _baseArmorOpenEvent.ReadFrom(this);
                    _baseArmorOpenEvent.Publish();
                }
            }
        }
    }
}