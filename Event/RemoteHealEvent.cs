using Event;

namespace JudgeSystem.Event
{
    public class RemoteHealEvent: IdentityHolderEvent, ICancelable
    {
        public bool IsCancelled { get; set; }
    }
}