using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Core.Game;
using TicTacToe.Core.Game.Contracts;
using TicTacToe.Core.GameRules.Contracts;
using TicTacToe.Core.Players;

namespace TicTacToe.Core.GameRules
{
    public class GameRuleService : IGameRule
    {
        private IEnumerable<Cordinate> _userCordinates;
        private readonly IEnumerable<CordinateSet> _winningCordinateSets;
        private IGameStatus _gameStatus;


        public GameRuleService(IGameStatus status)
        {
            _winningCordinateSets = new SquareWinningCordinateSetGenerator().GetWinningCordinateSetPermutations();
            _gameStatus = status;
        }

        public bool Validate(IEnumerable<Cordinate> userCordinates)
        {
            _userCordinates = userCordinates;
            return _winningCordinateSets.Any(x => CompareWithPlayerCordinates(x.Get()));
        }

        public MoveResult Scan(Cordinate cordinate)
        {
            var isOccupied =  _gameStatus.CurrentBoard.Cordinates.Single(x => x.X == cordinate.X && x.Y == cordinate.Y).IsOccupied;
            var result = new MoveResult();
            if (isOccupied)
            {
                result.Status = MoveStatus.AlreadyOccupied;
                return result;
            }
            result.Status = MoveStatus.MoveToNextRule;
            return result;
        }

        public bool GameFinished()
        {
            var currentPlayerCordinaates = GetPlayerCordinaates(_gameStatus.CurrentPlayer.Symbol);
            return Validate(currentPlayerCordinaates);
        }

        public bool GameDraws()
        {
            return !Validate(GetPlayerCordinaates(Constants.X)) &&
                   !Validate(GetPlayerCordinaates(Constants.O)) &&
                   _gameStatus.CurrentBoard.Cordinates.Count(x => x.IsOccupied) == 9;
        }

        private IEnumerable<Cordinate> GetPlayerCordinaates(char symbol)
        {
            var currentPlayerCordinaates =
                _gameStatus.CurrentBoard.Cordinates.Where(x => x.Symbol == symbol);
            return currentPlayerCordinaates;
        }

        /// <summary>
        ///     Compare user cordinate set to a winning cordinate set and return true
        ///     if all cordinates are equal
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        private bool CompareWithPlayerCordinates(IEnumerable<Cordinate> enumerable)
        {
            var returnFlag = true;
            var orderedWinningSet = enumerable.OrderBy(x => x.X).ThenBy(y => y.Y).ToArray();
            var orderedPlayerSet = _userCordinates.OrderBy(x => x.X).ThenBy(y => y.Y).ToArray();

            foreach (var winningSet in orderedWinningSet)
            {
                var match = orderedPlayerSet.Any(x => x.X == winningSet.X && x.Y == winningSet.Y);
                if (!match)
                    returnFlag = false;
            }
            return returnFlag;
        }
    }
}

