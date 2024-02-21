using Event;
using JudgeSystem.Buffs;
using JudgeSystem.Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Robots
{
    public partial class Infantry: IChassisHolder
    {
        private Chassis _chassis;

        private readonly ChassisSelectionEvent _chassisSelectionEvent = new();
        
        public int ChassisMaxPower { get; private set; }
        public int Chassis
        {
            get => (int) _chassis;
            set
            {
                if (Chassis == value) return;
                _chassis = (Chassis) value;
                _chassisSelectionEvent.Reset();
                _chassisSelectionEvent.ReadFrom(this);
                _chassisSelectionEvent.Publish();

                UpdateChassisValue();
            }
        }

        public int MaxPower
        {
            get
            {
                if (Buffs.TryGet<PowerBuff>(out var buff))
                {
                    return (int)(ChassisMaxPower * buff.PowerMultiplier);
                }
                
                return ChassisMaxPower;
            }
        }

        private void UpdateChassisValue()
        {
            if (!Performance.Predefined.Chassis.TryGetValue(_chassis, out var values))
            {
                JudgeSystemWarningEvent.RaiseNew("Infantry", $"Chassis {_chassis} not found in predefined chassis values");
                return;
            }

            ChassisMaxPower = values[_level].MaxPower;
            MaxHealth = values[_level].MaxHealth;
        }

        [EventSubscriber]
        private void OnLevelUp(ref LevelUpEvent evt)
        {
            if (!evt.Fits(this)) return;
            UpdateChassisValue();
            UpdateGunValue();
        }
    }
}