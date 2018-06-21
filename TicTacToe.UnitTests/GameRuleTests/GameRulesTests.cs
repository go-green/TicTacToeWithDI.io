
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TicTacToe.Core.Game;
using TicTacToe.Core.Game.Contracts;
using TicTacToe.Core.GameRules;
using TicTacToe.Core.GameRules.Contracts;
using TicTacToe.Core.Players;

namespace TicTacToe.UnitTests.GameRuleTests
{
    public class GameRulesTests
    {
        private IGameRule _gameRulesService;
        private IGameStatus _gameStatus;
        private IGameBoard _board;

        [SetUp]
        public void SetUp()
        {
            _board = new GameBoard();
            _gameStatus = new GameStatus(_board);
            _gameRulesService = new GameRuleService(_gameStatus);
        }

        [Test]
        public void ValidCordinateSetChecks()
        {
            var cords1 = new List<Cordinate>();
            cords1.Add(new Cordinate() { X = 1, Y = 1 });
            cords1.Add(new Cordinate() { X = 2, Y = 2 });
            cords1.Add(new Cordinate() { X = 3, Y = 3 });
            Assert.IsTrue(_gameRulesService.Validate(cords1));


            var cords2 = new List<Cordinate>();
            cords2.Add(new Cordinate() { X = 1, Y = 3 });
            cords2.Add(new Cordinate() { X = 2, Y = 2 });
            cords2.Add(new Cordinate() { X = 3, Y = 1 });
            Assert.IsTrue(_gameRulesService.Validate(cords2));


            var cords3 = new List<Cordinate>();
            cords3.Add(new Cordinate() { X = 1, Y = 1 });
            cords3.Add(new Cordinate() { X = 1, Y = 2 });
            cords3.Add(new Cordinate() { X = 1, Y = 3 });
            Assert.IsTrue(_gameRulesService.Validate(cords3));
        }

        [Test]
        public void InvalidCordinateSetChecks()
        {
            var cords = new List<Cordinate>();
            cords.Add(new Cordinate() { X = 1, Y = 1 });
            cords.Add(new Cordinate() { X = 2, Y = 2 });
            cords.Add(new Cordinate() { X = 1, Y = 3 });
            Assert.IsFalse(_gameRulesService.Validate(cords));
        }
    }
}
