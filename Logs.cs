using Event;

namespace JudgeSystem
{
    public static class Logs
    {
        public static ILogger Logger { get; set; }
        
        public static void Log(ILogger.LogLevel level, string message, params object[] args)
        {
            Logger?.Log(level, message, args);
        }
        
        public static void I(string message, params object[] args)
        {
            Log(ILogger.LogLevel.Info, message, args);
        }
        
        public static void W(string message, params object[] args)
        {
            Log(ILogger.LogLevel.Warning, message, args);
        }
        
        public static void E(string message, params object[] args)
        {
            Log(ILogger.LogLevel.Error, message, args);
        }
        
        public static void D(string message, params object[] args)
        {
            Log(ILogger.LogLevel.Debug, message, args);
        }
    }
}