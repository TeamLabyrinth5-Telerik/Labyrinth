using Labyrinth.Logic.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Labyrinth.Console;

namespace Labyrinth.Tests.Models
{
    [TestClass]
    public class TestConsole
    {
        [TestMethod]
        public void ConsoleReadlineMethod()
        {
            var fakeRender = new Mock<IUserInterface>();
            fakeRender.Setup(r => r.GetUserInput());
            fakeRender.Object.GetUserInput();
            fakeRender.Object.GetUserInput();
            fakeRender.Object.GetUserInput();
            fakeRender.Verify(r => r.GetUserInput(), Times.AtLeast(3));
        }
        [TestMethod]
        public void ConsoleReadKeyMethod()
        {
            var fakeRender = new Mock<IUserInterface>();
            fakeRender.Setup(r => r.GetButtonInput());
            fakeRender.Object.GetButtonInput();
            fakeRender.Object.GetButtonInput();
            fakeRender.Object.GetButtonInput();
            fakeRender.Verify(r => r.GetButtonInput(), Times.AtLeast(3));
        }

    }
}
