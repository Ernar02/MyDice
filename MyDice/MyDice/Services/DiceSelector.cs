using System;
using System.Collections.Generic;
using MyDice.Models;

namespace MyDice.Services
{
    internal class DiceSelector
    {
        private readonly List<Dice> _dices;
        private readonly UserInterface _ui;

        public DiceSelector(List<Dice> dices, UserInterface ui)
        {
            _dices = dices;
            _ui = ui;
        }

        public (Dice player, Dice computer) SelectDice(int firstMover)
        {
            Dice player, computer;

            if (firstMover == 0) 
            {
                Console.WriteLine("You make the first move. Choose your dice: ");
                PrintDiceChoices();
                int playerIndex = _ui.ReadIntInRange("Your choice: ", 0, _dices.Count - 1, null, _dices);
                player = _dices[playerIndex];
                computer = _dices[(playerIndex + 1) % _dices.Count];
            }
            else 
            {
                int computerIndex = 1;
                computer = _dices[computerIndex];
                Console.WriteLine($"I make the first move and choose the [{computer}] dice.");
                PrintDiceChoices(new HashSet<int> { computerIndex });

                int playerIndex = _ui.ReadIntInRange("Your choice: ", 0, _dices.Count - 1,
                    new HashSet<int> { computerIndex }, _dices);
                player = _dices[playerIndex];
            }

            Console.WriteLine($"You choose the [{player}] dice.");
            if (firstMover == 0) Console.WriteLine($"I choose the [{computer}] dice.");

            return (player, computer);
        }

        private void PrintDiceChoices(HashSet<int>? exclude = null)
        {
            for (int i = 0; i < _dices.Count; i++)
            {
                if (exclude == null || !exclude.Contains(i))
                    Console.WriteLine($"{i} - {_dices[i]}");
            }
        }
    }
}