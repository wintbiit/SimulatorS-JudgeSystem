using JudgeSystem.Buffs;

namespace JudgeSystem.Interfaces
{
    public interface IShooter: IIdentityHolder
    {
        public bool TryShoot();
        public uint AmmoShot { get; }
        public uint MaxAmmo { get; }
        public uint Heat { get; }
        public uint DeltaHeat { get; }
        public uint MaxHeat { get; }
        public bool TryBuyAmmo(int amount);
        public bool TryRemoteBuyAmmo(int amount);
        public int AmmoType { get; }
        public int GunType { get; }
        public int CalculateDamage(IHealthEntity target);
    }
}