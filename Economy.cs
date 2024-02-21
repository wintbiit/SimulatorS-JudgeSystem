using System;
using System.Collections.Concurrent;

namespace JudgeSystem
{
    public abstract class Economy: Entity
    {
        private readonly ConcurrentDictionary<Camp, int> _bank = new();
        private readonly ConcurrentDictionary<Camp, int> _income = new();
        
        protected MatchConfig MatchConfig;
        public JudgeSystem JudgeSystem;
        
        protected Economy(MatchConfig matchConfig)
        {
            MatchConfig = matchConfig;
            _bank[Camp.Red] = 0;
            _bank[Camp.Blue] = 0;
            _income[Camp.Red] = 0;
            _income[Camp.Blue] = 0;
        }
        
        public void IncreaseEconomy(Camp camp, int amount)
        {
            if (!_bank.ContainsKey(camp))
            {
                throw new ArgumentException($"Camp {camp} does not exist in the bank.");
            }
            
            _bank[camp] += amount;
            _income[camp] += amount;
        }
        
        public void IncreaseEconomy(int amount)
        {
            IncreaseEconomy(Camp.Red, amount);
            IncreaseEconomy(Camp.Blue, amount);
        }
        
        public void DecreaseEconomy(Camp camp, int amount)
        {
            if (!_bank.ContainsKey(camp))
            {
                throw new ArgumentException($"Camp {camp} does not exist in the bank.");
            }
            
            _bank[camp] -= amount;
        }
        
        public int GetEconomy(Camp camp)
        {
            if (!_bank.ContainsKey(camp))
            {
                throw new ArgumentException($"Camp {camp} does not exist in the bank.");
            }
            
            return _bank[camp];
        }
        
        public int GetIncome(Camp camp)
        {
            if (!_income.ContainsKey(camp))
            {
                throw new ArgumentException($"Camp {camp} does not exist in the income.");
            }
            
            return _income[camp];
        }
        
        public bool TryCost(Camp camp, int amount)
        {
            if (GetEconomy(camp) < amount)
            {
                return false;
            }
            
            DecreaseEconomy(camp, amount);
            return true;
        }
    }
}