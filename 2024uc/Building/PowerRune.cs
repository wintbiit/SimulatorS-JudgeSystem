using Event;
using JudgeSystem._2024uc.Building.Interfaces;
using JudgeSystem._2024uc.Event;
using JudgeSystem.Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Building
{
    public class PowerRune: global::JudgeSystem.Building, IPowerRuneController
    {
        public const ushort ID = 0x04;
        
        public PowerRune() : base(Camp.Judge, ID)
        {
        }
        
        private PowerRuneStatus _status;
        private readonly PowerRuneStartEvent _startEvent = new();
        private readonly PowerRuneEndEvent _endEvent = new();
        public PowerRuneStatus Status
        {
            get => _status;
            set
            {
                if (_status == value) return;
                _status = value;

                if (_status == PowerRuneStatus.Active)
                {
                    _startEvent.Reset();
                    _startEvent.ReadFrom(this);
                    _startEvent.Publish();
                } else if (_status == PowerRuneStatus.Inactive)
                {
                    _endEvent.Reset();
                    _endEvent.ReadFrom(this);
                    _endEvent.Publish();
                }
            }
        }
        
        public PowerRuneType Type { get; set; }
        public IIdentityHolder LastActivator { get; set; }
        public int LastRingCount { get; set; }
        
        private readonly PowerRuneActivateEvent _activateEvent = new();

        private readonly JudgeSystemWarningEvent _warningEvent = new JudgeSystemWarningEvent
        {
            Module = "PowerRune",
        };
        
        public void Activate(IIdentityHolder activator, int ringCount)
        {
            if (Status != PowerRuneStatus.Active)
            {
                _warningEvent.Message = "Trying to activate inactive power rune";
                _warningEvent.Publish();
            }
            
            LastActivator = activator;
            LastRingCount = ringCount;
            Status = PowerRuneStatus.Activated;
            
            _activateEvent.Reset();
            _activateEvent.ReadFrom(this);
            _activateEvent.Publish();
        }
    }
}