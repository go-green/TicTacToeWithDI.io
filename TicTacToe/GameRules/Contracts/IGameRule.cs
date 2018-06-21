using System.Collections.Generic;
using TicTacToe.Core.Players;

namespace TicTacToe.Core.GameRules.Contracts
{
    public interface IGameRule
    {
        bool Validate(IEnumerable<Cordinate> cordinates);
        MoveResult Scan(Cordinate cordinate);
        bool GameFinished();
        bool GameDraws();
    }
}
