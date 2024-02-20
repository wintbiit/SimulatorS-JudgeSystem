using Event;
using JudgeSystem._2024uc.Buildings.Interfaces;
using JudgeSystem._2024uc.Robots;
using JudgeSystem.Event;
using JudgeSystem.Interfaces;

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

        public int AmmoType => (int) Ammos.Dart;
        public int GunType => default;

        private readonly BuyAmmoEvent _buyAmmoEvent = new();
        public bool TryBuyAmmo(int amount)
        {
            JudgeSystemWarningEvent.RaiseNew("DartLauncher", "Trying to buy ammo. What are you doing?");
            return false;
        }

        private readonly RemoteBuyAmmoEvent _remoteBuyAmmoEvent = new();
        public bool TryRemoteBuyAmmo(int amount)
        {
            JudgeSystemWarningEvent.RaiseNew("DartLauncher", "Trying to remote buy ammo. What are you doing?");
            return false;
        }
        
        public DartLauncher(Camp camp): base(camp, ID)
        {
        }
        
        public int CalculateDamage(IHealthEntity target) => this.GenericDamageCalculate(target);
    }
}