namespace Labyrinth.Tests.Console
{
    using Labyrinth.Console;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestLabyrinthStarter
    {
        [TestMethod]
        public void TestGameStarterInstanceToBeUnique()
        {
            var firstInstance = LabyrinthStarter.Instance;
            var secondInstance = LabyrinthStarter.Instance;
            var expected = firstInstance.GetHashCode();
            var actual = secondInstance.GetHashCode();
            Assert.AreEqual(expected, actual);
        }
    }
}
