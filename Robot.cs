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

        protected Robot(int maxHealth, Camp camp, ushort id)
        {
            MaxHealth = maxHealth;
            _currentHealth = maxHealth;
            Camp = camp;
            Id = id;
        }
    }
}