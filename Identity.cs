namespace JudgeSystem
{
    public record Identity(Camp Camp, ushort Id)
    {
        public override string ToString()
        {
            return $"[{Camp}:{Id}]";
        }
    }
}

namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { }
}