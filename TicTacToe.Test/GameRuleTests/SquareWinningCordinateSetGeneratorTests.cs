
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TicTacToe.Core.GameRules;

namespace TicTacToe.Test.GameRuleTests
{
    public class SquareWinningCordinateSetGeneratorTests
    {
        private IEnumerable<CordinateSet> _cordinateSet;

        [SetUp]
        public void SetUp()
        {
            _cordinateSet = new SquareWinningCordinateSetGenerator().GetWinningCordinateSetPermutations();
        }

        [Test]
        public void WinningCordinateSetCountCheck()
        {
            
            Assert.AreEqual(_cordinateSet.Count(),8);
        }
    }
}
