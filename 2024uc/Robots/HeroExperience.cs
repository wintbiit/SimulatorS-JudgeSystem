using System;
using Event;
using JudgeSystem.Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Robots
{
    public partial class Hero: IExperienceHolder
    {
        private float _experience;
        private const float Tolerance = 0.2f;
        public float Experience
        {
            get => _experience;
            set
            {
                if (Math.Abs(_experience - value) < Tolerance) return;
                _experience = value;
                if (Performance.Predefined.LevelExperience.Contains(_level + 1)
                    && _experience > Performance.Predefined.LevelExperience[_level + 1])
                {
                    Level++;
                }
            }
        }

        public void AddExperience(float experience)
        {
            _experience += experience;
        }

        private ushort _level;
        private readonly LevelUpEvent _levelUpEvent = new();
        public ushort Level
        {
            get => _level;
            set
            {
                if (_level == value) return;
                _level = value;
                _levelUpEvent.ReadFrom(this);
                _levelUpEvent.Publish();
            }
        }
    }
}