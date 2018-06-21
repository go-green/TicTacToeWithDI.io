
using System.Linq;
using NUnit.Framework;
using TicTacToe.Core.GameRules;
using TicTacToe.Core.Players;

namespace TicTacToe.UnitTests.GameRuleTests
{
    public class CordinateSetTests
    {
        private CordinateSet _cordinateSet;

        [SetUp]
        public void SetUp()
        {
            _cordinateSet = new CordinateSet();
            _cordinateSet.Set(new Cordinate() { X = 3, Y = 3 });
            _cordinateSet.Set(new Cordinate() { X = 2, Y = 2 });
            _cordinateSet.Set(new Cordinate() { X = 1, Y = 1 });
        }

        [Test]
        public void CordinateSetCheck()
        {
            Assert.AreEqual(_cordinateSet.Get().Count(), 3);
        }

        [Test]
        public void CordinateSetOrderingCheck()
        {
            var orderedFirstElement = _cordinateSet.Get().OrderBy(x => x.X).First();
            Assert.AreEqual(orderedFirstElement.X, 1);
            Assert.AreEqual(orderedFirstElement.Y, 1);

            var orderedLastElement = _cordinateSet.Get().OrderBy(x => x.X).Last();
            Assert.AreEqual(orderedLastElement.X, 3);
            Assert.AreEqual(orderedLastElement.Y, 3);
        }
    }
}
