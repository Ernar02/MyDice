# 🎲 MyDice

**MyDice** is a cryptographically fair console dice game written in C#.  
It uses HMAC-based commitments to ensure transparent and tamper-proof randomness.

## 🧩 Features

- ✅ Cryptographically fair number generation using HMAC (pre-committed random values)
- 🎮 Interactive CLI gameplay between a player and the computer
- 🎲 Custom dice with configurable sides
- 🤖 Smart computer behavior
- 🛡️ Player can verify fairness using revealed HMAC keys

## ⚙️ How It Works

1. The computer generates a random number `x` and commits to it using HMAC.
2. The player (or computer) chooses a number `y`.
3. The final result is computed as `(x + y) % 6`, ensuring both sides contribute.
4. The original `x` and its HMAC key are revealed after the move for verification.

## 🚀 How to Run

Make sure you have [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or later installed.

You can exe .bat in \MyDice\bin\Debug\net6.0 
OR Use bash 

```bash
git clone https://github.com/Ernar02/MyDice.git
cd MyDice
dotnet build
dotnet run -- "2,2,4,4,9,9" "6,8,1,1,8,6" "7,5,3,7,5,3"
