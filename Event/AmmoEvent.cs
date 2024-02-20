using Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem.Event
{
    public class BuyAmmoEvent: IdentityHolderEvent<BuyAmmoEvent>
    {
        public int Count { get; set; }
        public ushort AmmoType { get; set; }

        public void ReadFrom(IShooter shooter)
        {
            base.ReadFrom(shooter);
            AmmoType = shooter.AmmoType;
        }
    }
    
    public class RemoteBuyAmmoEvent: IdentityHolderEvent<RemoteBuyAmmoEvent>
    {
        public int Count { get; set; }
        public ushort AmmoType { get; set; }
        
        public void ReadFrom(IShooter shooter)
        {
            base.ReadFrom(shooter);
            AmmoType = shooter.AmmoType;
        }
    }
}