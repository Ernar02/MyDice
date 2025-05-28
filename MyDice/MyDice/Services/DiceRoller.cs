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

            int y = who == "player"
               ? _ui.ReadIntInRange("Add your number modulo 6: ", 0, 5)
               : GetComputerInput();


            int resultIndex = (x + y) % 6;
            var dice = who == "player" ? _playerDice : _computerDice;
            int resultValue = dice.Sides[resultIndex];

            Console.WriteLine($"My number is {x} (KEY={hmacHelper.KeyHex}).");
            Console.WriteLine($"The fair number generation result is {x} + {y} = {resultIndex} (mod 6).");
            Console.WriteLine($"That corresponds to index {resultIndex} in {(who == "player" ? "your" : "my")} dice: value = {resultValue}.");

            return resultValue;
        }

        private int GetComputerInput()
        {
            int y = new Random().Next(0, 6);
            Console.WriteLine($"Computer uses number {y}.");
            return y;
        }
    }
}