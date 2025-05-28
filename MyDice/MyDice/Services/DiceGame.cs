using System;
using System.Collections.Generic;
using MyDice.Models;
using MyDice.Utils;

namespace MyDice.Services
{
    internal class DiceGame
    {
        private readonly List<Dice> _dices;
        private readonly UserInterface _ui = new UserInterface();
        private Dice? _playerDice;
        private Dice? _computerDice;

        public DiceGame(List<List<int>> dices)
        {
            if (dices == null) throw new ArgumentNullException(nameof(dices));
            if (dices.Count < 3) throw new ArgumentException($"You must provide at least 3 dice. Provided: {dices.Count}", nameof(dices));

            _dices = new List<Dice>();
            foreach (var sides in dices)
            {
                _dices.Add(new Dice(sides));
            }
        }

        public void Run()
        {
            var decider = new FirstMoverDecider(_ui);
            int firstMover = decider.Decide();

            ShowAllDice();
            var selector = new DiceSelector(_dices, _ui);
            (_playerDice, _computerDice) = selector.SelectDice(firstMover);

            var roller = new DiceRoller(_playerDice!, _computerDice!, _ui);
            int computerRollResult = roller.Roll("computer");
            int playerRollResult = roller.Roll("player");

            PrintResult(playerRollResult, computerRollResult);
        }

        private void ShowAllDice()
        {
            Console.WriteLine("Available dices:");
            for (int i = 0; i < _dices.Count; i++)
                Console.WriteLine($"{i} - {_dices[i]}");
        }

        private void PrintResult(int playerRoll, int computerRoll)
        {
            if (playerRoll > computerRoll)
                Console.WriteLine($"You win ({playerRoll} > {computerRoll})!");
            else if (playerRoll < computerRoll)
                Console.WriteLine($"I win ({computerRoll} > {playerRoll})!");
            else
                Console.WriteLine("It's a draw!");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}