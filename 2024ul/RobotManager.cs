namespace JudgeSystem._2024ul
{
    public static class RobotManagerExt
    {
        
    }

    public class RobotSelection
    {
        public bool RHero { get; set; }
        public InfantryStatus RInfantry1 { get; set; }
        public InfantryStatus RInfantry2 { get; set; }
        public bool RAutoSentinel { get; set; }
        
        public bool BHero { get; set; }
        public InfantryStatus BInfantry1 { get; set; }
        public InfantryStatus BInfantry2 { get; set; }
        public bool BAutoSentinel { get; set; }
     
        public enum InfantryStatus
        {
            None,
            Infantry,
            BalanceInfantry,
        }
    }
}