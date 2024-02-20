using Event;
using JudgeSystem.Event;

namespace JudgeSystem
{
    public partial class Robot
    {
        private float _experience;
        public float Experience
        {
            get => _experience;
            set
            {
                _experience = value;
            }
        }

        public void AddExperience(float experience)
        {
            _experience += experience;
        }

        private uint _level;

        private readonly LevelUpEvent _levelUpEvent = new();
        public uint Level
        {
            get => _level;
            set
            {
                if (_level == value) return;
                _levelUpEvent.Reset();
                _levelUpEvent.ReadFrom(this);
                _levelUpEvent.Publish();
            }
        }
    }
}