using Event;
using JudgeSystem.Event;

namespace JudgeSystem._2024uc.Events
{
    public class DroneSummonEvent: IdentityHolderEvent, ICancelable
    {
        public int Cost;
        public bool IsCancelled { get; set; }
    }
}