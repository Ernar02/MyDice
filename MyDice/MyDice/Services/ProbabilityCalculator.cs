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
   
    }
}