using Event;
using JudgeSystem._2024uc.Events;
using JudgeSystem._2024uc.Robots.Interfaces;

namespace JudgeSystem._2024uc.Robots
{
    public partial class Drone: IDroneController
    {
        private readonly DroneSummonEvent _droneSummonEvent = new ();
        public bool TrySummon()
        {
            _droneSummonEvent.ReadFrom(this);
            _droneSummonEvent.Publish();
            return !_droneSummonEvent.IsCancelled;
        }
    }
}