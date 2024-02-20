using Event;

namespace JudgeSystem.Event
{
    public class JudgeSystemWarningEvent: Event<JudgeSystemWarningEvent>
    {
        public string Module;
        public string Message;
        
        public static void RaiseNew(string module, string message)
        {
            var e = new JudgeSystemWarningEvent
            {
                Module = module,
                Message = message
            };
            e.Publish();
        }
    }
}