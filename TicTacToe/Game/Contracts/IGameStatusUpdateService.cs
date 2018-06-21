using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Core.Players;

namespace TicTacToe.Core.Game.Contracts
{
    public interface IGameStatusUpdateService
    {
        IGameStatus Status { get; }
        void UpdateBoard(Cordinate cords);
        void UpdatePlayer(Cordinate cords);
        void SwitchPlayer();
        void Reset();
    }
}
