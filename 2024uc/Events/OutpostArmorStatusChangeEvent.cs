using JudgeSystem._2024uc.Buildings.Interfaces;
using JudgeSystem.Event;

namespace JudgeSystem._2024uc.Event
{
    public class OutpostArmorStatusChangeEvent: IdentityHolderEvent<OutpostArmorStatusChangeEvent>
    {
        public OutpostArmorStatus ArmorStatus;

        public void ReadFrom(IOutpostController outpostController)
        {
            base.ReadFrom(outpostController);
            ArmorStatus = outpostController.ArmorStatus;
        }
    }
}