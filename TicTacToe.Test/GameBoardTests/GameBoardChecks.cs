

using System.Linq;
using NUnit.Framework;
using TicTacToe.Core.Game;
using TicTacToe.Core.Players;

namespace TicTacToe.Test.GameBoardTests
{

    public class GameBoardChecks
    {
        private GameBoard _gameBoard;

        [SetUp]
        public void SetUp()
        {
            _gameBoard = new GameBoard();
        }

        [Test]
        public void CheckTheCorrectInitializationOfCordinates()
        {
            Assert.AreEqual(_gameBoard.Cordinates.Count(), 9);
            Assert.AreEqual(_gameBoard.Cordinates.Count(x => x.IsOccupied == false), 9);
            Assert.AreEqual(_gameBoard.Cordinates.Count(x => x.Symbol == '*'), 9);
        }

        [Test]
        public void GameBoardUpdateTest()
        {
            var cords = new Cordinate(3, 3, 'X');
            _gameBoard.Update(cords);
            Assert.AreEqual(_gameBoard.Cordinates.Count(x => x.IsOccupied == false), 8);
            Assert.AreEqual(_gameBoard.Cordinates.Count(x => x.IsOccupied), 1);
            Assert.AreEqual(_gameBoard.Cordinates.Single(x => x.X == cords.X && x.Y == cords.Y).Symbol,'X');
        }

        [Test]
        public void GameBoardResetTest()
        {
            var cords = new Cordinate(3, 3, 'X');
            _gameBoard.Update(cords);
            _gameBoard.Reset();
            Assert.AreEqual(_gameBoard.Cordinates.Count(), 9);
            Assert.AreEqual(_gameBoard.Cordinates.Count(x => x.IsOccupied == false), 9);
            Assert.AreEqual(_gameBoard.Cordinates.Count(x => x.Symbol == '*'), 9);
        }










    }
}

