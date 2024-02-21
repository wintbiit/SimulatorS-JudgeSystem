using Event;
using JudgeSystem._2024uc.Buffs;
using JudgeSystem.Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Robots
{
    public partial class Infantry: Robot, IShooter
    {
        public const ushort ID_1 = 3;
        public const ushort ID_2 = 4;
        public const ushort ID_3 = 5;
        
        public Infantry(Camp camp, ushort id, JudgeSystem judgeSystem) : base(camp, id, judgeSystem)
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

        public uint Heat { get; private set; }

        public uint DeltaHeat {get; private set;}

        public uint MaxHeat { get; private set; }

        public int AmmoType => (int) Ammos.A17mm;
        private Guns _gunType = Guns.Cooldown17mm;
        public int CalculateDamage(IHealthEntity target) => this.GenericDamageCalculate(target);
        private readonly GunSelectionEvent _gunSelectionEvent = new();
        public int GunType
        {
            get => (int)_gunType;
            set
            {
                if (GunType == value) return;
                _gunType = (Guns) value;
                _gunSelectionEvent.Reset();
                _gunSelectionEvent.ReadFrom(this);
                _gunSelectionEvent.Publish();
                UpdateGunValue();
            }
        }
        
        private readonly BuyAmmoEvent _buyAmmoEvent = new();
        public bool TryBuyAmmo(int amount)
        {
            if (!Buffs.Has<HealZoneBuff>()) return false;
            
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

        private void UpdateGunValue()
        {
            MaxHeat = Performance.Predefined.Gun[_gunType][_level].MaxHeat;
            DeltaHeat = Performance.Predefined.Gun[_gunType][_level].DeltaHeat;
        }
    }
}