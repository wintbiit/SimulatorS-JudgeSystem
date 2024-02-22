using Event;
using JudgeSystem._2024uc.Buildings.Interfaces;
using JudgeSystem.Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Buildings
{
    public partial class Base: Building
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
        
        private int _shieldHealth;

        public int ShieldHealth
        {
            get => _shieldHealth;
            set
            {
                if (value < 0)
                {
                    _shieldHealth = 0;
                    ArmorStatus = BaseArmorStatus.Opened;
                }
                else if (value > MaxShieldHealth)
                {
                    _shieldHealth = MaxShieldHealth;
                }
                else
                {
                    _shieldHealth = value;
                }
            }
        }
        
        public int MaxShieldHealth { get; }
        
        public void TakeDamage(IShooter shooter)
        {
            if (!JudgeSystem.MatchConfig.FriendlyFire && shooter.Camp == Camp) return;

            if (_armorStatus != BaseArmorStatus.Opened && shooter is not DartLauncher)
            {
                ShieldHealth -= shooter.CalculateDamage(this);
            }
            else
            {
                Health -= shooter.CalculateDamage(this);
            }
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

        public Base(Camp camp) : base(camp, ID)
        {
            var maxHealth = Performance.Predefined.Buildings.BaseHealth;
            MaxHealth = maxHealth;
            _currentHealth = maxHealth;
            MaxShieldHealth = Performance.Predefined.Buildings.BaseShieldHealth;
            ArmorStatus = BaseArmorStatus.Closed;
        }
    }
}