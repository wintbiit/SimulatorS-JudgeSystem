namespace JudgeSystem.Interfaces
{
    public interface IHealthEntity: IIdentityHolder
    {
        public int Health { get; set; }
        public int MaxHealth { get; }
        public void TakeDamage(IShooter shooter);
        public bool TryRevive();
        public bool TryCoinRevive();
    }
}