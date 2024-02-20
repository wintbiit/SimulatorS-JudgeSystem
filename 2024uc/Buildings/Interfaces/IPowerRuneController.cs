using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Buildings.Interfaces
{
    public interface IPowerRuneController: IIdentityHolder
    {
        public void Activate(IIdentityHolder activator, int ringCount);
        public PowerRuneStatus Status { get; set; }
        public PowerRuneType Type { get; set;  }
        public IIdentityHolder LastActivator { get; set;  }
        public int LastRingCount { get; set;  }
    }
    
    public enum PowerRuneStatus
    {
        Inactive,
        Active,
        Activated
    }
    
    public enum PowerRuneType
    {
        Small,
        Large
    }
}