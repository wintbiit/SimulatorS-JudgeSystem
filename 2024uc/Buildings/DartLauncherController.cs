using Event;
using JudgeSystem._2024uc.Buildings.Interfaces;
using JudgeSystem._2024uc.Events;

namespace JudgeSystem._2024uc.Buildings
{
    public partial class DartLauncher: IDartLauncherController
    {
        private DartLauncherGateStatus _gateStatus;
        private readonly DartLauncherOpenEvent _openEvent = new();
        private readonly DartLauncherCloseEvent _closeEvent = new();

        public DartLauncherGateStatus GateStatus
        {
            get => _gateStatus;
            set
            {
                if (_gateStatus == value) return;
                _gateStatus = value;
                
                if (_gateStatus == DartLauncherGateStatus.Opened)
                {
                    _openEvent.ReadFrom(this);
                    _openEvent.Publish();
                }
                else
                {
                    _closeEvent.ReadFrom(this);
                    _closeEvent.Publish();
                }
            }
        }
    }
}