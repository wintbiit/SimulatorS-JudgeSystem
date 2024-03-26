using System;

namespace JudgeSystem
{
    [Serializable]
    public struct Identity
    {
        public Camp Camp;
        public ushort Id;
        
        public Identity(Camp camp, ushort id)
        {
            Camp = camp;
            Id = id;
        }
        
        public override string ToString()
        {
            return $"[{Camp}:{Id}]";
        }
    }
}

