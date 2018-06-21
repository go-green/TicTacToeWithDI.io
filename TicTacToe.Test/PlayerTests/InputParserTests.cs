
using NUnit.Framework;
using TicTacToe.Core.Players;

namespace TicTacToe.Test.PlayerTests
{
    
    public class InputParserTests
    {
        private InputParser _inputParser;

        [SetUp]
        public void Setup()
        {
            _inputParser = new InputParser();
        }

        [TestCase("Q", MoveStatus.Skpipped)]
        [TestCase("q", MoveStatus.Skpipped)]
        [TestCase(" ", MoveStatus.Invalid)]
        [TestCase(null, MoveStatus.Invalid)]
        [TestCase("0,0", MoveStatus.Invalid)]
        [TestCase("4,4", MoveStatus.Invalid)]
        [TestCase("3,3,3", MoveStatus.Invalid)]
        [TestCase("sdsdsd", MoveStatus.Invalid)]
        [TestCase("121212", MoveStatus.Invalid)]
        [TestCase("3,3", MoveStatus.Successful)]
        [TestCase("1,1", MoveStatus.Successful)]
        public void InputParserStatusTests(string input, MoveStatus moveStatus)
        {
            var result = _inputParser.Parse(input);
            Assert.AreEqual(result.Status,moveStatus);
        }

        [Test]
        public void InputParserCordinateTests()
        {
            var result = _inputParser.Parse("3,3");
            Assert.AreEqual(result.Cordinate.X, 3);
            Assert.AreEqual(result.Cordinate.Y, 3);
        }
    }
}
