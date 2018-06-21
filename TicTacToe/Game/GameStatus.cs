
using System.Collections.Generic;
using TicTacToe.Core.Game.Contracts;
using TicTacToe.Core.Players.Contracts;

namespace TicTacToe.Core.Game
{
    public class GameStatus : IGameStatus
    {
        public GameStatus(IGameBoard gameBoard)
        {
            CurrentBoard = gameBoard;
        }
        public IEnumerable<IPlayer> Players { get; set; }
        public IPlayer CurrentPlayer { get; set; }
        public IGameBoard CurrentBoard { get; set; }
    }
}
