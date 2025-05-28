using MyDice.Utils;
using System;

internal class FirstMoverDecider
{
    private readonly UserInterface _ui;

    public FirstMoverDecider(UserInterface ui)
    {
        _ui = ui;
    }

    public int Decide()
    {
        var hmacHelper = new HmacHelper(0, 1);
        int computerSelection = hmacHelper.Value;

        Console.WriteLine("Let's determine who makes the first move.");
        Console.WriteLine($"I selected a random value in the range 0..1 (HMAC={hmacHelper.Hmac})");
        Console.WriteLine("Try to guess my selection.\n0 - 0\n1 - 1\nX - exit\n? - help");

        int userGuess = _ui.ReadIntInRange("Your selection: ", 0, 1);

        Console.WriteLine($"My selection: {computerSelection} (KEY={hmacHelper.KeyHex})");

        if (userGuess == computerSelection)
        {
            Console.WriteLine("You guessed right!");
            return 0; 
        }
        else
        {
            Console.WriteLine("I make the first move.");
            return 1; 
        }
    }
}