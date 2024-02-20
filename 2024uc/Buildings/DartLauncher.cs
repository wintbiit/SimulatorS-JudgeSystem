using Event;
using JudgeSystem._2024uc.Buildings.Interfaces;
using JudgeSystem.Event;

namespace JudgeSystem._2024uc.Buildings
{
    public partial class DartLauncher: Building
    {
        public const ushort ID = 0x03;
        
        public bool TryShoot()
        {
            if (GateStatus != DartLauncherGateStatus.Opened) return false;
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

        public ushort AmmoType => Ammos.AmmoDart;
        
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
        
        public DartLauncher(Camp camp): base(camp, ID)
        {
        }
    }
}