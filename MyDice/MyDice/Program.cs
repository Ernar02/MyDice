using MyDice.Services;
using MyDice.Utils;
using System;

namespace MyDice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DiceArgumentsValidator.ValidateAndThrow(args);


                var diceConfigs = DiceArgumentsParser.Parse(args);
                if (diceConfigs == null)
                    throw new Exception("Failed to parse dice arguments.");

                var game = new DiceGame(diceConfigs);
                game.Run();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();

                Console.WriteLine("\nPress any key to Exit...");
                Console.ReadKey();
            }
        }
    }
}
