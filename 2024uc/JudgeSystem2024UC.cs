namespace JudgeSystem._2024uc
{
    public class JudgeSystem2024UC: JudgeSystem
    {
        private const int MaxTime2024UC = 420;
        
        public RobotSelection Selection { get; }
        
        public JudgeSystem2024UC(RobotSelection selection, MatchConfig matchConfig) : base(MaxTime2024UC, matchConfig, new Economy2024UC(matchConfig))
        {
            BuildingManager.Init();
            RobotManager.Init(this, selection);
            Selection = selection;
        }
    }
}