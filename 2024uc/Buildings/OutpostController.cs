using Event;
using JudgeSystem._2024uc.Buildings.Interfaces;
using JudgeSystem._2024uc.Events;

namespace JudgeSystem._2024uc.Buildings
{
    public partial class Outpost: IOutpostController
    {
        private OutpostArmorStatus _armorStatus;
        private readonly OutpostArmorStatusChangeEvent _outpostArmorStatusChangeEvent = new();
        public OutpostArmorStatus ArmorStatus
        {
            get => _armorStatus;
            set
            {
                if (_armorStatus == value) return;
                
                _armorStatus = value;
                _outpostArmorStatusChangeEvent.ReadFrom(this);
                _outpostArmorStatusChangeEvent.Publish();
            }
        }
    }
}