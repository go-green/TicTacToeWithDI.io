using System;
using TicTacToe.Core.Game.Contracts;
using TicTacToe.Core.GameRules.Contracts;
using TicTacToe.Core.Players;
using TicTacToe.Core.Players.Contracts;

namespace TicTacToe.Core.Game
{
    public partial class GameManager : IGameManager
    {

        private readonly IPlayerInteractionService _interactionService;
        private readonly IGameStatusUpdateService _statusUpdateService;
        private readonly IGameRule _gameRules;

        public GameManager(IPlayerInteractionService interactionService,
                           IGameStatusUpdateService statusUpdateService,
                           IGameRule rules)
        {
            _interactionService = interactionService;
            _statusUpdateService = statusUpdateService;
            _gameRules = rules;
        }

        public void StartNewGame()
        {
            PrintGameStartMessage();
            Play();
        }

        public void Play()
        {
            var moveResult = PlayerTakeTurn();
            while (GameNotFinished())
            {
                IsPositionOccupied(moveResult);
                switch (moveResult.Status)
                {
                    case MoveStatus.Invalid:
                        PrintInvalidMoveMessage();
                        break;
                    case MoveStatus.Successful:
                        UpdateGameStatus(moveResult.Cordinate);
                        ScanTheBoard(moveResult);
                        SwitchPlayer();
                        break;
                    case MoveStatus.Skpipped:
                        SwitchPlayer();
                        break;
                    case MoveStatus.AlreadyOccupied:
                        PrintAlreadyOccupiedMessage();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                moveResult = PlayerTakeTurn();
            }
        }

        public void Stop()
        {
            Console.ReadLine();
            Environment.Exit(0);
        }

        public void Reset()
        {
            _statusUpdateService.Reset();
        }
    }
}
