using Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem.Event
{
    public abstract class IdentityHolderEvent<T>: Event<T> where T: Event<T>
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
    }
}