using JudgeSystem.Interfaces;

namespace JudgeSystem
{
    public abstract class Zone: Entity, IZone
    {
        public Camp Camp { get; }
        public ushort Id { get; }
        protected JudgeSystem JudgeSystem;
        
        protected Zone(Camp camp, ushort id)
        {
            Camp = camp;
            Id = id;
        }
        
        public virtual void OnEnterZone(IRobot occupier)
        {
        }
        
        public virtual void OnExitZone(IRobot occupier)
        {
        }
    }
    
    public abstract class SeizableZone: Zone
    {
        public IRobot CurrentOccupier { get; private set; }
        private IRobot _lastEnteredOccupier;
        
        protected SeizableZone(Camp camp, ushort id) : base(camp, id)
        {
        }

        public override void OnEnterZone(IRobot occupier)
        {
            base.OnEnterZone(occupier);

            if (CurrentOccupier != null)
            {
                OnOccupy(occupier);
            }
            else if (_lastEnteredOccupier == null)
            {
                _lastEnteredOccupier = occupier;
            }
        }
        
        public override void OnExitZone(IRobot occupier)
        {
            base.OnExitZone(occupier);

            if (CurrentOccupier == occupier)
            {
                OnRelease(occupier);
            }
            
            if (_lastEnteredOccupier == occupier)
            {
                _lastEnteredOccupier = null;
            }
        }

        public virtual void OnOccupy(IRobot occupier)
        {
            CurrentOccupier = occupier;
        }
        
        public virtual void OnRelease(IRobot occupier)
        {
            if (CurrentOccupier == occupier)
            {
                CurrentOccupier = null;
            }

            if (_lastEnteredOccupier != null)
            {
                OnOccupy(_lastEnteredOccupier);
            }
        }
    }
    
    public abstract class RestrictedZone: Zone
    {
        public abstract bool CanEnter(IRobot occupier);
        
        protected RestrictedZone(Camp camp, ushort id) : base(camp, id)
        {
        }
    }
}