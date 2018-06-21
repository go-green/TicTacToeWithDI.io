using System.Collections.Generic;
using TicTacToe.Core.Players.Contracts;

namespace TicTacToe.Core.Game.Contracts
{
    public interface IGameStatus
    {
        IGameBoard CurrentBoard { get; set; }
        IPlayer CurrentPlayer { get; set; }
        IEnumerable<IPlayer> Players { get; set; }
    }
}