using Event;

namespace JudgeSystem.Event
{
    public class TickEvent: Event<TickEvent>
    {
        public int Time;
    }
}