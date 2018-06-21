using System.Collections.Generic;
using TicTacToe.Core.Players;

namespace TicTacToe.Core.Game.Contracts
{
    public interface IGameBoard
    {
        IEnumerable<Cordinate> Cordinates { get; set; }
        void Draw();
        void Update(Cordinate cords);
        void Reset();
    }
}
