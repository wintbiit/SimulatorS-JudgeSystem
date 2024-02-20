using JudgeSystem._2024uc.Robot;

namespace JudgeSystem._2024uc
{
    public class RobotManager: global::JudgeSystem.RobotManager
    {
        public Hero B1 => this[Camp.Blue, Hero.ID] as Hero;
        public Engineer B2 => this[Camp.Blue, Engineer.ID] as Engineer;
        public Infantry B3 => this[Camp.Blue, Infantry.ID_1] as Infantry;
        public Infantry B4 => this[Camp.Blue, Infantry.ID_2] as Infantry;
        public Infantry B5 => this[Camp.Blue, Infantry.ID_3] as Infantry;
        public Drone B6 => this[Camp.Blue, Drone.ID] as Drone;
        public AutoSentinel B7 => this[Camp.Blue, AutoSentinel.ID] as AutoSentinel;
        
        public Hero R1 => this[Camp.Red, Hero.ID] as Hero;
        public Engineer R2 => this[Camp.Red, Engineer.ID] as Engineer;
        public Infantry R3 => this[Camp.Red, Infantry.ID_1] as Infantry;
        public Infantry R4 => this[Camp.Red, Infantry.ID_2] as Infantry;
        public Infantry R5 => this[Camp.Red, Infantry.ID_3] as Infantry;
        public Drone R6 => this[Camp.Red, Drone.ID] as Drone;
        public AutoSentinel R7 => this[Camp.Red, AutoSentinel.ID] as AutoSentinel;
        
        
    }
}