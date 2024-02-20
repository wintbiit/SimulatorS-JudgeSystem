using JudgeSystem.Buffs;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Robots
{
    public static class RobotUtils
    {
        public static int GenericDamageCalculate(this IShooter shooter, IHealthEntity target)
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

            var ammo = (Ammos) shooter.AmmoType;
            var baseDamage = Performance.Predefined.AmmoDamage[ammo];
            
            return (int) (baseDamage * shootMultiplier * (1- defenceMultiplier));
        }
    }
}