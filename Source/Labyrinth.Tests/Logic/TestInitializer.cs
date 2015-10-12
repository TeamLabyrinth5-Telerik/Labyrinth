namespace Labyrinth.Tests.Logic
{
    using Labyrinth.Console.Interfaces;
    using Labyrinth.Logic;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Models;
    using Labyrinth.Models.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class TestInitializer
    {
        [TestMethod]
        public void GameInitializerMethodShouldBeInvokedOnce()
        {
            var fakeInitializer = new Mock<IInitializer>();
            var fakeGrid = new Mock<IGrid>();
            var fakePlayer = new Mock<IPlayer>();
            fakeInitializer.Object.InitializeGame(fakeGrid.Object, fakePlayer.Object);
            fakeInitializer.Verify(i => i.InitializeGame(fakeGrid.Object, fakePlayer.Object), Times.Exactly(1));
        }

        [TestMethod]
        public void GenerateGridMethodShouldBeReturnValidMatrixLength()
        {
            var grid = new Grid(7, 7);
            var player = new Player();
            var initializer = new Initializer();

            var actual = initializer.GenerateGrid(player, grid);
            var expextetHorizontalLength = 7;
            var expextetVerticalLength = 7;

            Assert.AreEqual(expextetHorizontalLength, actual.Field.GetLength(0));
            Assert.AreEqual(expextetVerticalLength, actual.Field.GetLength(1));
        }

        [TestMethod]
        public void MakeAtLeastOneExitReachableMethodShoudBeInvolkedOnce()
        {
            var fakeInitializer = new Mock<IInitializer>();
            var fakeGrid = new Mock<IGrid>();
            var fakePlayer = new Mock<IPlayer>();
            fakeInitializer.Object.InitializeGame(fakeGrid.Object, fakePlayer.Object);
            fakeInitializer.Verify(m => m.MakeAtLeastOneExitReachable(fakeGrid.Object, fakePlayer.Object), Times.Exactly(0));
        }
    }
}
