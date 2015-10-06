using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Models;

namespace Labyrinth.Tests
{
    [TestClass]
    public class TestPlayer
    {
        [TestMethod]
        public void TestPlayerConstructorIfReturnsValidNameState()
        {
            var player = new Player();
            var actual = player.Name;
            var expected = "Guest";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestPlayerConstructorIfReturnValidMovesState()
        {
            var player = new Player();
            var actual = player.MoveCount;
            var expected = 0;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestPlayerConstructorIfInputIsProvidedReturnsValidNameState()
        {
            var player = new Player("Pesho");
            var actual = player.Name;
            var expected = "Pesho";
            Assert.AreEqual(actual, expected);
        }
    }
}
