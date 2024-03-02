using JudgeSystem.Interfaces;

namespace JudgeSystem.Event
{
    public class LevelUpEvent: IdentityHolderEvent
    {
        public uint Level;
        
        public void ReadFrom(IExperienceHolder experienceHolder)
        {
            base.ReadFrom(experienceHolder);
            Level = experienceHolder.Level;
        }
    }
}