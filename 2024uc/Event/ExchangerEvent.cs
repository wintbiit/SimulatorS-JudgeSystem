using JudgeSystem._2024uc.Building.Interfaces;
using JudgeSystem.Event;

namespace JudgeSystem._2024uc.Event
{
    public class ExchangerGradeSelectEvent: IdentityHolderEvent<ExchangerGradeSelectEvent>
    {
        public int Grade;
    }
    
    public class ExchangeOreEvent: IdentityHolderEvent<ExchangeOreEvent>
    {
        public Ore Ore;
        public int Grade;
    }
}