using System.Collections.Generic;

namespace TicTacToe.Core.Players.Contracts
{
    public interface IPlayer
    {
        char Symbol { get; set; }
        int MoveCount { get; set; }
        int Id { get; set; }
        MoveResult Move();
    }
}