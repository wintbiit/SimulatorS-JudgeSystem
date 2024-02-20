using System;
using System.Linq;
using JudgeSystem._2024uc.Robot;
using JudgeSystem.Buffs;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Zone
{
    /// <summary>
    /// 高地增益区
    /// <remarks>5.3.2.2</remarks>
    /// </summary>
    public class HighlandZone: SeizableZone
    {
        public const ushort ID = 0x03;
        public HighlandZone() : base(Camp.Judge, ID)
        {
        }
        
        private static readonly CoolDownBuff Cool2 = new (float.MaxValue, 2f);
        private static readonly CoolDownBuff Cool3 = new (float.MaxValue, 3f);
        private static readonly CoolDownBuff Cool5 = new (float.MaxValue, 5f);
        
        private static readonly Type[] SeizableRobots = new[]
        {
            typeof(Hero),
            typeof(AutoSentinel),
            typeof(Infantry)
        };

        public override void OnEnterZone(IRobot robot)
        {
            if (!SeizableRobots.Contains(robot.GetType())) return;
            base.OnEnterZone(robot);

            if (CurrentOccupier.Camp == robot.Camp)
            {
                ApplyBuff(robot);
            }
        }

        public override void OnExitZone(IRobot robot)
        {
            if (!SeizableRobots.Contains(robot.GetType())) return;
            
            if (CurrentOccupier.Camp == robot.Camp)
            {
                RemoveBuff(robot);
            }
            
            base.OnExitZone(robot);
        }

        private void ApplyBuff(IBuffHolder buffHolder)
        {
            switch (JudgeSystem.Time)
            {
                case > 120f and < 180f:
                    buffHolder.AddBuff(Cool2);
                    break;
                case > 180f and < 300f:
                    buffHolder.AddBuff(Cool3);
                    break;
                case > 300f and < 420f:
                    buffHolder.AddBuff(Cool5);
                    break;
            }
        }
        
        private static void RemoveBuff(IBuffHolder buffHolder)
        {
            buffHolder.RemoveBuff<CoolDownBuff>();
        }
    }
}