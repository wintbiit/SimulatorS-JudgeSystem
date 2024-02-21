using JudgeSystem._2024uc.Buildings.Interfaces;
using JudgeSystem.Event;

namespace JudgeSystem._2024uc.Events
{
    public class ExchangerGradeSelectEvent: IdentityHolderEvent<ExchangerGradeSelectEvent>
    {
        public int Grade;
    }
    
    public class ExchangeOreEvent: IdentityHolderEvent<ExchangeOreEvent>
    {
        public Ore Ore;
        public int Grade;
        public int HoldTime;
    }
}