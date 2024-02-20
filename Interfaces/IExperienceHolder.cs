namespace JudgeSystem.Interfaces
{
    public interface IExperienceHolder: IIdentityHolder
    {
        public float Experience { get; }
        public void AddExperience(float experience);
        public uint Level { get; }
    }
}