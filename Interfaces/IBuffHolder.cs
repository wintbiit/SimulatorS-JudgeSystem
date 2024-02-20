namespace JudgeSystem.Interfaces
{
    public interface IBuffHolder: IIdentityHolder
    {
        public bool TryGetBuff<T>(out T buff) where T : Buff<T>;
        public bool HasBuff<T>() where T : Buff<T>;
        public void AddBuff<T>(T buff, bool overwrite = false) where T : Buff<T>;
        public void RemoveBuff<T>() where T : Buff<T>;
    }
}