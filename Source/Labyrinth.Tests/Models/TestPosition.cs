namespace Labyrinth.Tests.Models
{
    using System;
    using Labyrinth.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestPosition
    {
        [TestMethod]
        public void TestPositionConstructurIfSetAndReturnXValidValue()
        {
            var position = new Position(5, 6);
            var actual = position.X;
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPositionConstructurIfSetAndReturnYValidValue()
        {
            var position = new Position(5, 6);
            var actual = position.Y;
            var expected = 6;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCloneMethodIfReturnNewInstanceOfPosition()
        {
            var position = new Position();
            var clonetPosition = position.Clone();

            Assert.AreNotSame(clonetPosition, position);
        }
    }
}
