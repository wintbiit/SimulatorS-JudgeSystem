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
        public ushort AmmoType { get; }
    }

    public static class ShooterHelper
    {
        public static int CalculateDamage(this IShooter shooter, IHealthEntity target)
        {
            var shootMultiplier = 1f;
            if (shooter is IBuffHolder buffHolder)
            {
                if (buffHolder.TryGetBuff<DamageBuff>(out var damageBuff))
                {
                    shootMultiplier *= damageBuff.DamageMultiplier;
                }
            }
            
            var defenceMultiplier = 0f;
            if (target is IBuffHolder targetBuffHolder)
            {
                if (targetBuffHolder.TryGetBuff<DefenceBuff>(out var defenceBuff))
                {
                    defenceMultiplier = defenceBuff.DefenceMultiplier;
                }
            }
            
            return (int) (GetBaseDamage(shooter.AmmoType) * shootMultiplier * (1- defenceMultiplier));
        }

        public static int GetBaseDamage(ushort ammoId)
        {
            // TODO: Implement performance system
            return 0;
        }
    }
}