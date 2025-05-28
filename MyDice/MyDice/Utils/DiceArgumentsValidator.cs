using System;
using System.Linq;

namespace MyDice.Utils
{
    public static class DiceArgumentsValidator
    {
        public static void ValidateAndThrow(string[] args)
        {
            if (args.Length < 3)
                throw new ArgumentException($"You must provide at least 3 dice as arguments. Provided: {args.Length}");

            foreach (var arg in args)
            {
                ValidateDiceStringAndThrow(arg);
            }
        }

        public static bool Validate(string[] args)
        {
            try
            {
                ValidateAndThrow(args);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Validation error: {ex.Message}");
                return false;
            }
        }

        private static void ValidateDiceStringAndThrow(string diceString)
        {
            var parts = diceString.Split(',');

            if (parts.Length != 6)
                throw new FormatException($"Each dice must have exactly 6 sides. Problem with: '{diceString}'");

            if (parts.Any(part => !IsValidNumber(part)))
                throw new FormatException($"Invalid dice format: '{diceString}'");
        }

        private static bool IsValidNumber(string part)
        {
            return int.TryParse(part.Trim(), out int value) && value >= 1;
        }
    }
}
