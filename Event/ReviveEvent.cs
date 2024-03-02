using Event;

namespace JudgeSystem.Event
{
    public class ReviveEvent: IdentityHolderEvent, ICancelable
    {
        public bool IsCancelled { get; set; }
    }
    
    public class RemoteReviveEvent: IdentityHolderEvent, ICancelable
    {
        public bool IsCancelled { get; set; }
    }
}