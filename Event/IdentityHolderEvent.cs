using Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem.Event
{
    public abstract class IdentityHolderEvent
    {
        public Camp Camp;
        public ushort Id;
        
        public void ReadFrom(IIdentityHolder identity)
        {
            Camp = identity.Camp;
            Id = identity.Id;
        }
        
        public bool Fits(IIdentityHolder identity)
        {
            return Camp == identity.Camp && Id == identity.Id;
        }
        
        public string Identity()
        {
            return $"[{Camp}:{Id}]";
        }
    }
}