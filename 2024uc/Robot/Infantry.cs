using Event;
using JudgeSystem.Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Robot
{
    public class Infantry: global::JudgeSystem.Robot, IShooter
    {
        public const ushort ID_1 = 3;
        public const ushort ID_2 = 4;
        public const ushort ID_3 = 5;
        
        public Infantry(int maxHealth, Camp camp, ushort id): base(maxHealth, camp, id)
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

        public ushort AmmoType => Ammos.Ammo17mm;
        
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