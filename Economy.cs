using System;
using System.Collections.Concurrent;

namespace JudgeSystem
{
    public abstract class Economy: Entity
    {
        private readonly ConcurrentDictionary<Camp, int> _bank = new();
        
        protected MatchConfig MatchConfig;
        
        protected Economy(MatchConfig matchConfig)
        {
            MatchConfig = matchConfig;
            _bank.TryAdd(Camp.Red, matchConfig.RedInitialEconomy);
            _bank.TryAdd(Camp.Blue, matchConfig.BlueInitialEconomy);
        }
        
        private void IncreaseEconomy(Camp camp, int amount)
        {
            if (!_bank.ContainsKey(camp))
            {
                throw new ArgumentException($"Camp {camp} does not exist in the bank.");
            }
            
            _bank[camp] += amount;
        }
        
        private void DecreaseEconomy(Camp camp, int amount)
        {
            if (!_bank.ContainsKey(camp))
            {
                throw new ArgumentException($"Camp {camp} does not exist in the bank.");
            }
            
            _bank[camp] -= amount;
        }
        
        private void SetEconomy(Camp camp, int amount)
        {
            if (!_bank.ContainsKey(camp))
            {
                throw new ArgumentException($"Camp {camp} does not exist in the bank.");
            }
            
            _bank[camp] = amount;
        }
        
        public int GetEconomy(Camp camp)
        {
            if (!_bank.ContainsKey(camp))
            {
                throw new ArgumentException($"Camp {camp} does not exist in the bank.");
            }
            
            return _bank[camp];
        }
        
        public int this[Camp camp]
        {
            get => GetEconomy(camp);
            set => SetEconomy(camp, value);
        }

        public int RedEconomy
        {
            get => GetEconomy(Camp.Red);
            set => SetEconomy(Camp.Red, value);
        }
        
        public int BlueEconomy
        {
            get => GetEconomy(Camp.Blue);
            set => SetEconomy(Camp.Blue, value);
        }
    }
}