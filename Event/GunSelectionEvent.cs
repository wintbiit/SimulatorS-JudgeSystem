using JudgeSystem.Interfaces;

namespace JudgeSystem.Event
{
    public class GunSelectionEvent: IdentityHolderEvent
    {
        public int Gun;

        public void ReadFrom(IShooter shooter)
        {
            base.ReadFrom(shooter);
            Gun = shooter.GunType;
        }
    }
}