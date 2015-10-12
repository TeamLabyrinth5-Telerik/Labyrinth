namespace Labyrinth.Tests.Logic
{
    using Labyrinth.Console.Interfaces;
    using Labyrinth.Logic;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Models.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class TestLabyrinthEngine
    {
        [TestMethod]
        public void LabyrinthEngineRunMethodShouldBeInvokedOnce()
        {
            var mockedEngine = new Mock<IEngine>();
            mockedEngine.Setup(x => x.Run());
            mockedEngine.Object.Run();
            mockedEngine.Verify(x => x.Run(), Times.Exactly(1));
        }

        [TestMethod]
        public void EngineShouldBeInstanceOfTypeIEngine()
        {
            var fakeInitializer = new Mock<IInitializer>().Object as IInitializer;
            var fakeUserInterface = new Mock<IUserInterface>().Object as IUserInterface;
            var fakeRenderer = new Mock<IRenderer>().Object as IRenderer;
            var fakePlayer = new Mock<IPlayer>().Object as IPlayer;
            var fakeGrid = new Mock<IGrid>().Object as IGrid;

            var engine = new LabyrinthEngine(fakeRenderer, fakeUserInterface, fakeInitializer, fakePlayer, fakeGrid);

            Assert.IsInstanceOfType(engine, typeof(IEngine));
        }
    }
}
