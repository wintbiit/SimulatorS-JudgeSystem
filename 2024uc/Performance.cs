using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JudgeSystem._2024uc
{
    [Serializable]
    public partial struct Performance
    {
        public struct ChassisPerformance
        {
            public int MaxHealth;
            public int MaxPower;
        }

        public Dictionary<Chassis, List<ChassisPerformance>> Chassis;
        
        public List<int> LevelExperience;
        
        public static Performance Predefined;// = JsonConvert.DeserializeObject<Performance>("");
    }
}