using System;

namespace JudgeSystem
{
    [Serializable]
    public record MatchConfig
    {
        /// <summary>
        /// 启用友军伤害
        /// </summary>
        public bool FriendlyFire;
        
        /// <summary>
        /// 比赛开始前等待时间
        /// </summary>
        public int WaitTime;
        
        /// <summary>
        /// 结算等待时间
        /// </summary>
        public int StatisticTime;
        
        /// <summary>
        /// 裁判系统时钟周期
        /// <remarks>unit: ms</remarks>
        /// </summary>
        public int TickPeriod;
        
        /// <summary>
        /// 红方初始经济
        /// </summary>
        public int RedInitialEconomy;
        
        /// <summary>
        /// 蓝方初始经济
        /// </summary>
        public int BlueInitialEconomy;
    }
}