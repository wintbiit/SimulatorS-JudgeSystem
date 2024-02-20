namespace JudgeSystem._2024uc
{
    public class JudgeSystem2024UC: JudgeSystem
    {
        public JudgeSystem2024UC(RobotSelection selection)
        {
            BuildingManager.Init();
            RobotManager.Init(this, selection);
        }

        public override float MaxTime => 420;
    }
}