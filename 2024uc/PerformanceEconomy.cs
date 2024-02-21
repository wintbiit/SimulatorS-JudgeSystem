using System.Collections.Generic;
using JudgeSystem._2024uc.Buildings.Interfaces;

namespace JudgeSystem._2024uc
{
    public partial struct Performance
    {
        public struct EconomyPerformance
        {
            public struct AmmoConfig
            {
                public int Local;
                public int Remote;
                public int MaxExchange;
            }
            
            public Dictionary<Ammos, AmmoConfig> AmmoPrices;
        }
        
        public EconomyPerformance Economy;
        public int MaxDroneSummon;
        public Dictionary<int, Dictionary<Ore, int>> OrePrices;
    }
}