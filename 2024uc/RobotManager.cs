using JudgeSystem._2024uc.Robots;

namespace JudgeSystem._2024uc
{
    public static class RobotManagerExt
    {
        public static Hero B1(this RobotManager robotManager) => robotManager[Camp.Blue, Hero.ID] as Hero;
        public static Engineer B2(this RobotManager robotManager) => robotManager[Camp.Blue, Engineer.ID] as Engineer;
        public static Infantry B3(this RobotManager robotManager) => robotManager[Camp.Blue, Infantry.ID_1] as Infantry;
        public static Infantry B4(this RobotManager robotManager) => robotManager[Camp.Blue, Infantry.ID_2] as Infantry;
        public static Infantry B5(this RobotManager robotManager) => robotManager[Camp.Blue, Infantry.ID_3] as Infantry;
        public static Drone B6(this RobotManager robotManager) => robotManager[Camp.Blue, Drone.ID] as Drone;
        public static AutoSentinel B7(this RobotManager robotManager) => robotManager[Camp.Blue, AutoSentinel.ID] as AutoSentinel;
        
        public static Hero R1(this RobotManager robotManager) => robotManager[Camp.Red, Hero.ID] as Hero;
        public static Engineer R2(this RobotManager robotManager) => robotManager[Camp.Red, Engineer.ID] as Engineer;
        public static Infantry R3(this RobotManager robotManager) => robotManager[Camp.Red, Infantry.ID_1] as Infantry;
        public static Infantry R4(this RobotManager robotManager) => robotManager[Camp.Red, Infantry.ID_2] as Infantry;
        public static Infantry R5(this RobotManager robotManager) => robotManager[Camp.Red, Infantry.ID_3] as Infantry;
        public static Drone R6(this RobotManager robotManager) => robotManager[Camp.Red, Drone.ID] as Drone;
        public static AutoSentinel R7(this RobotManager robotManager) => robotManager[Camp.Red, AutoSentinel.ID] as AutoSentinel;

        public static void Init(this RobotManager manager, JudgeSystem judgeSystem, RobotSelection selection)
        {
            if (selection.RHero) manager.Add(new Hero(Camp.Red, judgeSystem));
            if (selection.REngineer) manager.Add(new Engineer(Camp.Red, judgeSystem));
            if (selection.RInfantry1 == RobotSelection.InfantryStatus.Infantry) manager.Add(new Infantry(Camp.Red, Infantry.ID_1, judgeSystem));
            if (selection.RInfantry1 == RobotSelection.InfantryStatus.BalanceInfantry) manager.Add(new BalanceInfantry(Camp.Red, Infantry.ID_1, judgeSystem));
            if (selection.RInfantry2 == RobotSelection.InfantryStatus.Infantry) manager.Add(new Infantry(Camp.Red, Infantry.ID_2, judgeSystem));
            if (selection.RInfantry2 == RobotSelection.InfantryStatus.BalanceInfantry) manager.Add(new BalanceInfantry(Camp.Red, Infantry.ID_2, judgeSystem));
            if (selection.RInfantry3 == RobotSelection.InfantryStatus.Infantry) manager.Add(new Infantry(Camp.Red, Infantry.ID_3, judgeSystem));
            if (selection.RInfantry3 == RobotSelection.InfantryStatus.BalanceInfantry) manager.Add(new BalanceInfantry(Camp.Red, Infantry.ID_3, judgeSystem));
            if (selection.RDrone) manager.Add(new Drone(Camp.Red, judgeSystem));
            if (selection.RAutoSentinel) manager.Add(new AutoSentinel(Camp.Red, judgeSystem));
            
            if (selection.BHero) manager.Add(new Hero(Camp.Blue, judgeSystem));
            if (selection.BEngineer) manager.Add(new Engineer(Camp.Blue, judgeSystem));
            if (selection.BInfantry1 == RobotSelection.InfantryStatus.Infantry) manager.Add(new Infantry(Camp.Blue, Infantry.ID_1, judgeSystem));
            if (selection.BInfantry1 == RobotSelection.InfantryStatus.BalanceInfantry) manager.Add(new BalanceInfantry(Camp.Blue, Infantry.ID_1, judgeSystem));
            if (selection.BInfantry2 == RobotSelection.InfantryStatus.Infantry) manager.Add(new Infantry(Camp.Blue, Infantry.ID_2, judgeSystem));
            if (selection.BInfantry2 == RobotSelection.InfantryStatus.BalanceInfantry) manager.Add(new BalanceInfantry(Camp.Blue, Infantry.ID_2, judgeSystem));
            if (selection.BInfantry3 == RobotSelection.InfantryStatus.Infantry) manager.Add(new Infantry(Camp.Blue, Infantry.ID_3, judgeSystem));
            if (selection.BInfantry3 == RobotSelection.InfantryStatus.BalanceInfantry) manager.Add(new BalanceInfantry(Camp.Blue, Infantry.ID_3, judgeSystem));
            if (selection.BDrone) manager.Add(new Drone(Camp.Blue, judgeSystem));
            if (selection.BAutoSentinel) manager.Add(new AutoSentinel(Camp.Blue, judgeSystem));
        }
    }

    public class RobotSelection
    {
        public bool RHero { get; set; }
        public bool REngineer { get; set; }
        public InfantryStatus RInfantry1 { get; set; }
        public InfantryStatus RInfantry2 { get; set; }
        public InfantryStatus RInfantry3 { get; set; }
        public bool RDrone { get; set; }
        public bool RAutoSentinel { get; set; }
        
        public bool BHero { get; set; }
        public bool BEngineer { get; set; }
        public InfantryStatus BInfantry1 { get; set; }
        public InfantryStatus BInfantry2 { get; set; }
        public InfantryStatus BInfantry3 { get; set; }
        public bool BDrone { get; set; }
        public bool BAutoSentinel { get; set; }
     
        public enum InfantryStatus
        {
            None,
            Infantry,
            BalanceInfantry,
        }
    }
}