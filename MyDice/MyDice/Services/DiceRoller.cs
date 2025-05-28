using System;
using MyDice.Models;
using MyDice.Utils;

namespace MyDice.Services
{
    internal class DiceRoller
    {
        private readonly Dice _playerDice;
        private readonly Dice _computerDice;
        private readonly UserInterface _ui;

        public DiceRoller(Dice player, Dice computer, UserInterface ui)
        {
            _playerDice = player;
            _computerDice = computer;
            _ui = ui;
        }

        public int Roll(string who)
        {
            var hmacHelper = new HmacHelper(0, 5);
            int x = hmacHelper.Value;
            Console.WriteLine($"I selected a random value in the range 0..5 (HMAC={hmacHelper.Hmac})");

            int y = GetPlayerInput(); 

            int resultIndex = (x + y) % 6;
            var dice = who == "player" ? _playerDice : _computerDice;
            int resultValue = dice.Sides[resultIndex];

            Console.WriteLine($"My number is {x} (KEY={hmacHelper.KeyHex}).");
            Console.WriteLine($"The fair number generation result is {x} + {y} = {resultIndex} (mod 6).");

            if (who == "player")
            {
                Console.WriteLine($"Your roll result is {resultValue}.");
            }
            else
            {
                Console.WriteLine($"My roll result is {resultValue}.");
            }

            return resultValue;
        }

        private int GetPlayerInput()
        {
            Console.WriteLine("Add your number modulo 6.");
            Console.WriteLine("0 - 0");
            Console.WriteLine("1 - 1");
            Console.WriteLine("2 - 2");
            Console.WriteLine("3 - 3");
            Console.WriteLine("4 - 4");
            Console.WriteLine("5 - 5");
            Console.WriteLine("X - exit");
            Console.WriteLine("? - help");
            Console.Write("Your selection: ");

   
            return _ui.ReadIntInRange("", 0, 5);
        }

    }
}