using System;
using Event;
using JudgeSystem;
using JudgeSystem._2024uc;

namespace Web_Daemon;

internal class Program
{
    public static void Main(string[] args)
    {
        var selection = new RobotSelection()
        {
            RHero = true,
            REngineer = true,
            RInfantry1 = RobotSelection.InfantryStatus.Infantry,
            RInfantry2 = RobotSelection.InfantryStatus.Infantry,
            RInfantry3 = RobotSelection.InfantryStatus.Infantry,
            RDrone = true,
            RAutoSentinel = true,
            BHero = true,
            BEngineer = true,
            BInfantry1 = RobotSelection.InfantryStatus.Infantry,
            BInfantry2 = RobotSelection.InfantryStatus.Infantry,
            BInfantry3 = RobotSelection.InfantryStatus.Infantry,
            BDrone = true,
            BAutoSentinel = true
        };
        
        var config = new MatchConfig()
        {
            FriendlyFire = false,
            WaitTime = 10,
            StatisticTime = 10,
            TickPeriod = 1,
        };
        
        var logger = new Logger();
        EventManager.Logger = logger;
        LogUtils.Logger = logger;
        
        var judgeSystem = new JudgeSystem2024UC(selection, config);
        judgeSystem.Start();
        judgeSystem.Wait();
    }
}

internal class Logger : ILogger
{
    public ILogger.LogLevel MinLevel { get; set; }
    
    public void Log(ILogger.LogLevel level, string message, params object[] args)
    {
        if (level < MinLevel)
        {
            return;
        }
        Console.WriteLine($"[{level}]"+message, args);
    }
}