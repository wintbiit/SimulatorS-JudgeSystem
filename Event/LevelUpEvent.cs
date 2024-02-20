using JudgeSystem.Interfaces;

namespace JudgeSystem.Event
{
    public class LevelUpEvent: IdentityHolderEvent<LevelUpEvent>
    {
        public uint Level;
        
        public void ReadFrom(IExperienceHolder experienceHolder)
        {
            base.ReadFrom(experienceHolder);
            Level = experienceHolder.Level;
        }
    }
}