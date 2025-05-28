using MyDice.Models;
using MyDice.Renders;

    internal class UserInterface
    {
        public int ReadIntInRange(string prompt, int min, int max, HashSet<int>? exclude = null, List<Dice>? helpDices = null)
        {
            Console.Write(prompt);
            while (true)
            {
                var input = Console.ReadLine()?.Trim().ToLower();
                if (input == "x") Environment.Exit(0);
                if (input == "?")
                {
                    if (helpDices != null)
                    {
                        ProbabilityTable.Render(helpDices);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Help: You can enter a number from the allowed range.");
                        Console.WriteLine("No dice data available to show the probability table.");
                        Console.ResetColor();
                    }
                    Console.Write(prompt);
                    continue;
                }
                if (int.TryParse(input, out int value) &&
                    value >= min &&
                    value <= max &&
                    (exclude == null || !exclude.Contains(value)))
                {
                    return value;
                }
                Console.Write("Invalid input. Try again: ");
            }
        }
    }
