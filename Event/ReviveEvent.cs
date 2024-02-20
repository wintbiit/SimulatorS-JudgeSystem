namespace JudgeSystem.Event
{
    public class ReviveEvent: IdentityHolderEvent<ReviveEvent>
    {
        public int Cost;
        public bool Remote;
        
        public override void Reset()
        {
            base.Reset();
            Cost = 0;
            Remote = false;
        }
    }
}