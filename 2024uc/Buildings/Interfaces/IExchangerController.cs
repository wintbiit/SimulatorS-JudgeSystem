﻿using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Buildings.Interfaces
{
    public interface IExchangerController: IIdentityHolder
    {
        public int ExchangeGrade { get; set; }
        public void Exchange(IIdentityHolder exchanger, Ore ore);
    }

    public enum Ore
    {
        Gold,
        Sliver
    }
}