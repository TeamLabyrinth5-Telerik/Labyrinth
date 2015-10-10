namespace Labyrinth.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Telerik.JustMock;
    using Models.Interfaces;
    using System.Linq;

    [TestClass]
    public class TestScoreboard
    {
        private Scoreboard scoreboard;
        private Player player;

        [TestMethod]
        public void ShouldReturnZeroWhenHaveEmptyList()
        {
            scoreboard = new Scoreboard();
            var actual = scoreboard.Players.Count;
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldAddPlayerToList()
        {
            scoreboard = new Scoreboard();
            player = new Player();
            scoreboard.AddPlayer(player);

            var actual = scoreboard.Players.Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldAddPlayerWithNameToList()
        {
            scoreboard = new Scoreboard();
            player = new Player("Stamat");
            scoreboard.AddPlayer(player);

            var expected = player.Name;
            var actual = scoreboard.Players.FirstOrDefault().Name;

            Assert.AreEqual(expected, actual);
        }
    }
}
