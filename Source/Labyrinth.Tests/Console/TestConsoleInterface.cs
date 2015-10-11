namespace Labyrinth.Tests.Console
{
    using System;
    using System.Collections.Generic;

    using Labyrinth.Console;
    using Labyrinth.Logic.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Labyrinth.Common.Enums;

    [TestClass]
    public class TestConsoleInterface
    {
        [TestMethod]
        public void TestConsoleReadlineMethod()
        {
            var fakeRender = new Mock<IUserInterface>();
            fakeRender.Setup(r => r.GetUserInput());
            fakeRender.Object.GetUserInput();
            fakeRender.Object.GetUserInput();
            fakeRender.Object.GetUserInput();
            fakeRender.Verify(r => r.GetUserInput(), Times.AtLeast(3));
        }

        [TestMethod]
        public void TestConsoleReadKeyMethod()
        {
            var fakeRender = new Mock<IUserInterface>();
            fakeRender.Setup(r => r.GetButtonInput());
            fakeRender.Object.GetButtonInput();
            fakeRender.Object.GetButtonInput();
            fakeRender.Object.GetButtonInput();
            fakeRender.Verify(r => r.GetButtonInput(), Times.AtLeast(3));
        }

        [TestMethod]
        public void TestGetUserInputToReturnCorrectValue()
        {
            var mockedReader = new Mock<HelperReader>();
            Console.SetIn(mockedReader.Object);

            IList<string> input = new List<string>() { "DOWNARROW", "UPARROW", "LEFTARROW", "RIGHTARROW" };

            int indexOfCommand = 0;
            mockedReader.Setup(r => r.ReadLine()).Returns(() => input[indexOfCommand]);

            IUserInterface userInterface = new ConsoleInterface();
            string result;
            for (; indexOfCommand < input.Count; indexOfCommand++)
            {
                result = userInterface.GetUserInput();
                Assert.AreEqual(input[indexOfCommand], result);
            }

            mockedReader.Verify(r => r.ReadLine(), Times.Exactly(input.Count));
        }

        [TestMethod]
        public void ExitGameMethodShouldBeInvokedOnce()
        {
            var fakeInitializer = new Mock<IUserInterface>();
            fakeInitializer.Object.ExitGame();
            fakeInitializer.Verify(i => i.ExitGame(), Times.Exactly(1));
        }
    }
}
