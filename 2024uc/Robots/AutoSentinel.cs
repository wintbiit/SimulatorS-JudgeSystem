using Event;
using JudgeSystem.Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Robots
{
    public partial class AutoSentinel: Robot, IShooter
    {
        public const ushort ID = 7;

        public AutoSentinel(Camp camp, JudgeSystem judgeSystem) : base(camp, ID, judgeSystem)
        {
            
        }
        
        private int _lastShootTick;
        public bool TryShoot()
        {
            if (AmmoShot > MaxAmmo) return false;
            
            AmmoShot++;
            
            Heat += DeltaHeat;
            _lastShootTick = JudgeSystem.Time;
            return true;
        }

        public uint AmmoShot { get; private set; }
        
        public uint MaxAmmo { get; private set; }

        private uint _heat;
        public uint Heat
        {
            get => _heat;
            private set
            {
                if (value == _heat) return;
                _heat = value;

                if (_heat > MaxHeat)
                {
                    // TODO: 超热量惩罚
                }
            }
        }

        public uint DeltaHeat => 0;

        public uint MaxHeat => 100;

        public int AmmoType => (int) Ammos.A17mm;

        public int GunType => default;
        public int CalculateDamage(IHealthEntity target) => this.GenericDamageCalculate(target);

        private readonly BuyAmmoEvent _buyAmmoEvent = new();
        public bool TryBuyAmmo(int amount)
        {
            _buyAmmoEvent.Reset();
            _buyAmmoEvent.ReadFrom(this);
            _buyAmmoEvent.Count = amount;
            _buyAmmoEvent.Publish();

            if (!_buyAmmoEvent.Cancelled)
            {
                MaxAmmo += (uint) amount;
            }
            
            return !_buyAmmoEvent.Cancelled;
        }

        private readonly RemoteBuyAmmoEvent _remoteBuyAmmoEvent = new();
        public bool TryRemoteBuyAmmo(int amount)
        {
            _remoteBuyAmmoEvent.Reset();
            _remoteBuyAmmoEvent.ReadFrom(this);
            _remoteBuyAmmoEvent.Count = amount;
            _remoteBuyAmmoEvent.Publish();

            if (!_remoteBuyAmmoEvent.Cancelled)
            {
                MaxAmmo += (uint) amount;
            }
            
            return !_remoteBuyAmmoEvent.Cancelled;
        }
    }
}