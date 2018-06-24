
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Core.Game.Contracts;
using TicTacToe.Core.Players;
using TicTacToe.Core.Players.Contracts;

namespace TicTacToe.Core.Game
{
    public class GameStatusUpdateService : IGameStatusUpdateService
    {
        public GameStatusUpdateService(IGameStatus gameStatus,
                                       IEnumerable<IPlayer> players)
        {
            Status = gameStatus;
            Status.Players = players;
            InitializePlayers();
        }

        public IGameStatus Status { get; }

        private void InitializePlayers()
        {
            var player_x = Status.Players.First();
            player_x.Id = 1;
            player_x.Symbol = Constants.X;
            var player_y = Status.Players.Last();
            player_y.Id = 2;
            player_y.Symbol = Constants.O;
            Status.CurrentPlayer = Status.Players.FirstOrDefault();
        }

        public void UpdateBoard(Cordinate cords)
        {
            var cordinate = Status.CurrentBoard.Cordinates.Single(x => x.X == cords.X && x.Y == cords.Y);
            cordinate.IsOccupied = true;
            cordinate.Symbol = Status.CurrentPlayer.Symbol;
        }

        public void UpdatePlayer(Cordinate cords)
        {
            Status.CurrentPlayer.MoveCount++;
        }

        public void SwitchPlayer()
        {
            Status.CurrentPlayer = Status.Players.Single(x => x.Symbol != Status.CurrentPlayer.Symbol);
        }

        public void Reset()
        {
            Status.CurrentBoard.Reset();
        }
    }
}
