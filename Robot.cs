using JudgeSystem.Buffs;
using JudgeSystem.Interfaces;

namespace JudgeSystem
{
    public abstract partial class Robot: Entity, IRobot
    {
        protected JudgeSystem JudgeSystem;
        
        public Camp Camp { get; }
        public ushort Id { get; }

        public void OnTick()
        {
            if (HasBuff<HealBuff>())
            {
                _damageRecord.Clear();
            }
        }

        protected Robot(Camp camp, ushort id, JudgeSystem judgeSystem)
        {
            Camp = camp;
            Id = id;
            JudgeSystem = judgeSystem;
        }
    }
}