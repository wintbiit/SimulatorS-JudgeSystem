using System;
using System.Collections.Concurrent;

namespace JudgeSystem
{
    public abstract class Economy
    {
        protected JudgeSystem JudgeSystem;
        
        private readonly ConcurrentDictionary<Camp, float> _bank = new ConcurrentDictionary<Camp, float>();
        
        public Economy(JudgeSystem judgeSystem)
        {
            JudgeSystem = judgeSystem;
        }

        protected abstract void OnTick(float deltaTime);
        
        private void IncreaseEconomy(Camp camp, float amount)
        {
            if (!_bank.ContainsKey(camp))
            {
                throw new ArgumentException($"Camp {camp} does not exist in the bank.");
            }
            
            _bank[camp] += amount;
        }
        
        private void DecreaseEconomy(Camp camp, float amount)
        {
            if (!_bank.ContainsKey(camp))
            {
                throw new ArgumentException($"Camp {camp} does not exist in the bank.");
            }
            
            _bank[camp] -= amount;
        }
        
        private void SetEconomy(Camp camp, float amount)
        {
            if (!_bank.ContainsKey(camp))
            {
                throw new ArgumentException($"Camp {camp} does not exist in the bank.");
            }
            
            _bank[camp] = amount;
        }
        
        public float GetEconomy(Camp camp)
        {
            if (!_bank.ContainsKey(camp))
            {
                throw new ArgumentException($"Camp {camp} does not exist in the bank.");
            }
            
            return _bank[camp];
        }
        
        public float this[Camp camp]
        {
            get => GetEconomy(camp);
            set => SetEconomy(camp, value);
        }

        public float RedEconomy
        {
            get => GetEconomy(Camp.Red);
            set => SetEconomy(Camp.Red, value);
        }
        
        public float BlueEconomy
        {
            get => GetEconomy(Camp.Blue);
            set => SetEconomy(Camp.Blue, value);
        }
    }
}