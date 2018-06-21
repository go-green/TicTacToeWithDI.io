using System;
using TicTacToe.Core.Players.Contracts;

namespace TicTacToe.Core.Players
{
    public class ConsoleInteractionService : IPlayerInteractionService
    {
        public string GetPlayerInput()
        {
            return Console.ReadLine();
        }

        public void SetPlayerOutPut(string output)
        {
            Console.WriteLine(output);
        }
    }
}