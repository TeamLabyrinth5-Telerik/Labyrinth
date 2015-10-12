namespace Labyrinth.Tests.Models
{
    using System.Linq;
    using Labyrinth.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestScoreboard
    {
        private Scoreboard scoreboard;
        private Player player;

        [TestMethod]
        public void ShouldReturnZeroWhenHaveEmptyList()
        {
            this.scoreboard = new Scoreboard();
            var actual = this.scoreboard.Players.Count;
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldAddPlayerToList()
        {
            this.scoreboard = new Scoreboard();
            this.player = new Player();
            this.scoreboard.AddPlayer(this.player);

            var actual = this.scoreboard.Players.Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldAddPlayerWithNameToList()
        {
            this.scoreboard = new Scoreboard();
            this.player = new Player("Stamat");
            this.scoreboard.AddPlayer(this.player);

            var expected = this.player.Name;
            var actual = this.scoreboard.Players.FirstOrDefault().Name;

            Assert.AreEqual(expected, actual);
        }
    }
}
