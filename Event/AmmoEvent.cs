using Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem.Event
{
    public class BuyAmmoEvent: IdentityHolderEvent, ICancelable
    {
        public int Count { get; set; }
        public int AmmoType { get; set; }

        public void ReadFrom(IShooter shooter)
        {
            base.ReadFrom(shooter);
            AmmoType = shooter.AmmoType;
        }

        public bool IsCancelled { get; set; } = false;
    }
    
    public class RemoteBuyAmmoEvent: IdentityHolderEvent, ICancelable
    {
        public int Count { get; set; }
        public int AmmoType { get; set; }
        
        public void ReadFrom(IShooter shooter)
        {
            base.ReadFrom(shooter);
            AmmoType = shooter.AmmoType;
        }

        public bool IsCancelled { get; set; }
    }
}