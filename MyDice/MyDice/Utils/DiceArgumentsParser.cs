using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDice.Utils
{
    public static class DiceArgumentsParser
    {
        public static List<List<int>> Parse(string[] args)
        {
            var diceList = new List<List<int>>();

            foreach (var arg in args)
            {
                try
                {
                    var sides = arg
                        .Split(',')
                        .Select(s => int.Parse(s.Trim()))
                        .ToList();

                    if (sides.Count != 6)
                    {
                        Console.WriteLine($"Error: Dice '{arg}' must have exactly 6 numbers.");
                        return null;
                    }

                    diceList.Add(sides);
                }
                catch
                {
                    Console.WriteLine($"Error: Failed to parse dice string '{arg}'");
                    return null;
                }
            }

            return diceList;
        }
    }
}