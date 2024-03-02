using Event;
using JudgeSystem._2024uc.Buildings.Interfaces;
using JudgeSystem._2024uc.Events;

namespace JudgeSystem._2024uc.Buildings
{
    public partial class Base: IBaseController
    {
        private BaseArmorStatus _armorStatus;
        private readonly BaseArmorOpenEvent _baseArmorOpenEvent = new();
        public BaseArmorStatus ArmorStatus
        {
            get => _armorStatus;
            set
            {
                if (_armorStatus == value) return;
                _armorStatus = value;
                if (_armorStatus == BaseArmorStatus.Opened)
                {
                    _baseArmorOpenEvent.ReadFrom(this);
                    _baseArmorOpenEvent.Publish();
                }
            }
        }
    }
}