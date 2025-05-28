using ConsoleTables;
using MyDice.Models;
using MyDice.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDice.Renders
{
    public static class ProbabilityTable
    {
        public static void Render(List<Dice> dices)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Probability of the win for the user:");
            Console.ResetColor();

            var headers = new List<string> { "User dice v" };
            headers.AddRange(dices.Select(Shorten));

            var table = new ConsoleTable(headers.ToArray());

            for (int i = 0; i < dices.Count; i++)
            {
                var row = new List<object> { Shorten(dices[i]) };

                for (int j = 0; j < dices.Count; j++)
                {
                    row.Add(i == j
                        ? "- (0.3333)"
                        : ProbabilityCalculator.CalculateWinChance(dices[i].Sides.ToList(), dices[j].Sides.ToList())
                            .ToString("0.0000"));
                }

                table.AddRow(row.ToArray());
            }

            table.Write(Format.Alternative);
        }

        private static string Shorten(Dice dice) => $"{dice.Sides[0]},{dice.Sides[1]},{dice.Sides[2]}";
    }
}