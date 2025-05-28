using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDice.Services
{
    public static class ProbabilityCalculator
    {
        public static double CalculateWinChance(List<int> diceA, List<int> diceB)
        {
            if (diceA == null) throw new ArgumentNullException(nameof(diceA));
            if (diceB == null) throw new ArgumentNullException(nameof(diceB));
            if (diceA.Count == 0) throw new ArgumentException("DiceA cannot be empty.", nameof(diceA));
            if (diceB.Count == 0) throw new ArgumentException("DiceB cannot be empty.", nameof(diceB));

            int wins = 0;
            int total = diceA.Count * diceB.Count;

            foreach (var a in diceA)
            {
                foreach (var b in diceB)
                {
                    if (a > b)
                        wins++;
                }
            }

            return (double)wins / total;
        }

        public static double CalculateDrawChance(List<int> diceA, List<int> diceB)
        {
            if (diceA == null) throw new ArgumentNullException(nameof(diceA));
            if (diceB == null) throw new ArgumentNullException(nameof(diceB));

            int draws = 0;
            int total = diceA.Count * diceB.Count;

            foreach (var a in diceA)
            {
                draws += diceB.Count(b => a == b);
            }

            return (double)draws / total;
        }

        public static (double winChance, double drawChance, double loseChance) CalculateAllChances(List<int> diceA, List<int> diceB)
        {
            double winChance = CalculateWinChance(diceA, diceB);
            double drawChance = CalculateDrawChance(diceA, diceB);
            double loseChance = 1.0 - winChance - drawChance;

            return (winChance, drawChance, loseChance);
        }
    }
}