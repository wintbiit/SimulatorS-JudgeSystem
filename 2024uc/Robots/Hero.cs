﻿using Event;
using JudgeSystem._2024uc.Buffs;
using JudgeSystem.Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Robots
{
    public partial class Hero: Robot, IShooter
    {
        public const ushort ID = 1;
        
        public Hero(Camp camp, JudgeSystem judgeSystem) : base(camp, ID, judgeSystem)
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

        public uint DeltaHeat { get; private set; }

        public uint MaxHeat { get; private set; }

        public int AmmoType => (int) Ammos.A42mm;

        private Guns _gunType = Guns.Default42mm;
        public int CalculateDamage(IHealthEntity target) => this.GenericDamageCalculate(target);
        private readonly GunSelectionEvent _gunSelectionEvent = new();
        public int GunType
        {
            get => (int) _gunType;
            set
            {
                if ((int)_gunType == value) return;
                _gunType = (Guns) value;
                _gunSelectionEvent.ReadFrom(this);
                _gunSelectionEvent.Publish();
                UpdateGunValue();
            }
        }
        
        private readonly BuyAmmoEvent _buyAmmoEvent = new();
        public bool TryBuyAmmo(int amount)
        {
            if (!Buffs.Has<HealZoneBuff>()) return false;
            
            _buyAmmoEvent.ReadFrom(this);
            _buyAmmoEvent.Count = amount;
            _buyAmmoEvent.Publish();

            if (!_buyAmmoEvent.IsCancelled)
            {
                MaxAmmo += (uint) amount;
            }
            
            return !_buyAmmoEvent.IsCancelled;
        }

        private readonly RemoteBuyAmmoEvent _remoteBuyAmmoEvent = new();
        public bool TryRemoteBuyAmmo(int amount)
        {
            _remoteBuyAmmoEvent.ReadFrom(this);
            _remoteBuyAmmoEvent.Count = amount;
            _remoteBuyAmmoEvent.Publish();

            if (!_remoteBuyAmmoEvent.IsCancelled)
            {
                MaxAmmo += (uint) amount;
            }
            
            return !_remoteBuyAmmoEvent.IsCancelled;
        }
        
        private void UpdateGunValue()
        {
            MaxHeat = Performance.Predefined.Gun[_gunType][_level].MaxHeat;
            DeltaHeat = Performance.Predefined.Gun[_gunType][_level].DeltaHeat;
        }
    }
}