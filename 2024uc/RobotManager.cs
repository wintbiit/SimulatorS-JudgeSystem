using JudgeSystem._2024uc.Robot;

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
    }
}