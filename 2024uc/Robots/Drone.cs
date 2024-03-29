﻿using Event;
using JudgeSystem.Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Robots
{
    public partial class Drone: Robot, IShooter
    {
        public const ushort ID = 6;
        
        public Drone(Camp camp, JudgeSystem judgeSystem) : base(camp, ID, judgeSystem)
        {
            
        }
        
        public bool TryShoot()
        {
            if (AmmoShot > MaxAmmo) return false;
            
            AmmoShot++;
            
            // TODO: 超热量惩罚
            Heat += DeltaHeat;
            return true;
        }

        public uint AmmoShot { get; private set; }
        
        public uint MaxAmmo { get; private set; }

        public uint Heat { get; private set; }

        public uint DeltaHeat => 0;

        public uint MaxHeat => 100;

        public int AmmoType => (int)Ammos.Dart;
        
        public int GunType => default;
        public int CalculateDamage(IHealthEntity target) => this.GenericDamageCalculate(target);
        
        private readonly BuyAmmoEvent _buyAmmoEvent = new();
        public bool TryBuyAmmo(int amount)
        {
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
    }
}