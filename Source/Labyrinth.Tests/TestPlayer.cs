namespace Labyrinth.Tests
{
    using System;
    using Labyrinth.Common;
    using Labyrinth.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestPlayer
    {
        [TestMethod]
        public void TestPlayerConstructorIfReturnsValidNameState()
        {
            var player = new Player();
            var actual = player.Name;
            var expected = "Guest";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerConstructorIfReturnValidMovesState()
        {
            var player = new Player();
            var actual = player.MoveCount;
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerConstructorIfInputIsProvidedReturnsValidNameState()
        {
            var player = new Player("Pesho");
            var actual = player.Name;
            var expected = "Pesho";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerConstructorIfReturnValidInitialPositionX()
        {
            var player = new Player();
            var actual = player.Position.X;
            var expected = GlobalConstants.StartPlayerPositionX;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerConstructorIfReturnValidInitialPositionY()
        {
            var player = new Player();
            var actual = player.Position.X;
            var expected = GlobalConstants.StartPlayerPositionY;
            Assert.AreEqual(expected, actual);
        }
    }
}
