using System.Collections.Generic;

namespace JudgeSystem._2024uc
{
    public partial struct Performance
    {
        public struct GunPerformance
        {
            public uint MaxHeat;
            public uint DeltaHeat;
        }
        
        public Dictionary<Guns, List<GunPerformance>> Gun;
    }
}