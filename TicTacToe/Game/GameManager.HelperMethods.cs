using System;
using TicTacToe.Core.Players;

namespace TicTacToe.Core.Game
{
    public partial class GameManager
    {
        private void ScanTheBoard(MoveResult result)
        {
            if (_gameRules.GameFinished())
            {
                PrintGameFinishedMessage();
                Stop();
            }
            else if (_gameRules.GameDraws())
            {
                PrintGameDrawMessage();
                Stop();
            }
            else
            {
                PrintMoveAcceptedMessage();
            }
        }

        private void IsPositionOccupied(MoveResult result)
        {
            if (_gameRules.Scan(result.Cordinate).Status == MoveStatus.AlreadyOccupied)
            {
                PrintAlreadyOccupiedMessage();
            }
        }

        private void PrintAlreadyOccupiedMessage()
        {
            _interactionService.SetPlayerOutPut(Constants.POSITIONOCCUPIED);
        }

        private void PrintMoveAcceptedMessage()
        {
            _interactionService.SetPlayerOutPut(Constants.MOVEACCEPTED);
            _statusUpdateService.Status.CurrentBoard.Draw();
        }

        private void PrintGameDrawMessage()
        {
            _interactionService.SetPlayerOutPut(Constants.MOVEACCEPTED);
            _interactionService.SetPlayerOutPut(Constants.ALLPOSITIONSOCCUPIED);
        }

        private void PrintGameFinishedMessage()
        {
            _interactionService.SetPlayerOutPut(Constants.MOVEACCEPTED);
            _interactionService.SetPlayerOutPut(Constants.YOUWON);
        }

        private void PrintInvalidMoveMessage()
        {
            _interactionService.SetPlayerOutPut(Constants.INVALIDCORDINATES);
        }

        private void UpdateGameStatus(Cordinate cords)
        {
            _statusUpdateService.UpdateBoard(cords);
            _statusUpdateService.UpdatePlayer(cords);
        }

        private bool GameNotFinished()
        {
            return !_gameRules.GameFinished();
        }

        private void SwitchPlayer()
        {
            _statusUpdateService.SwitchPlayer();
        }

        private void PrintGameStartMessage()
        {
            _interactionService.SetPlayerOutPut(Constants.WELCOME);
            _interactionService.SetPlayerOutPut(Constants.CURRENTBOARD);
            _statusUpdateService.Status.CurrentBoard.Draw();
        }

        private MoveResult PlayerTakeTurn()
        {
            var currentPlayer = _statusUpdateService.Status.CurrentPlayer;
            _interactionService.SetPlayerOutPut(string.Format(Constants.ENTERCORDINATES, currentPlayer.Id, currentPlayer.Symbol));
            return currentPlayer.Move();
        }
    }
}
