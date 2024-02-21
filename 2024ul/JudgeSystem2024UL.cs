namespace JudgeSystem._2024ul
{
    public class JudgeSystem2024UL: JudgeSystem
    {
        private const int MaxTime2024UC = 420;
        
        public RobotSelection Selection { get; }
        
        public JudgeSystem2024UL(RobotSelection selection, MatchConfig matchConfig) : base(MaxTime2024UC, matchConfig, new Economy2024UL(matchConfig))
        {
            Selection = selection;
        }
    }
}