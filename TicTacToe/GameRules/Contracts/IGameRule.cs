using System.Collections.Generic;
using TicTacToe.Core.Players;

namespace TicTacToe.Core.GameRules.Contracts
{
    public interface IGameRule
    {
        bool Validate(IEnumerable<Cordinate> cordinates);
        MoveResult Scan(MoveResult cordinate);
        bool GameFinished();
        bool GameDraws();
    }
}
