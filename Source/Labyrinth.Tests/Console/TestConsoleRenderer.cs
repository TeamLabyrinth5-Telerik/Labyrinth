namespace Labyrinth.Tests.Console
{
    using System;
    using System.Collections.Generic;

    using Labyrinth.Console;
    using Labyrinth.Models;
    using Labyrinth.Common;
    using GameFifteen.ConsoleTests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    

    [TestClass]
    public class TestConsoleRenderer
    {
        [TestMethod]
        public void TestRenderScoreBoardWhenNoPlayersInScoreBoard()
        {
            var mockedWrited = new Mock<HelperWriter>();
            Console.SetOut(mockedWrited.Object);

            ConsoleRenderer renderer = new ConsoleRenderer();
            Scoreboard scoreBoard = new Scoreboard();

            renderer.PrintScore(scoreBoard);

            mockedWrited.Verify(w => w.WriteLine(It.Is<string>(str => str == "The scoreboard is empty.")), Times.AtLeastOnce);
        }

        [TestMethod]
        public void TestRenderScoreboardToPrintCorrectPlayers()
        {
            var mockedWrited = new Mock<HelperWriter>();
            Console.SetOut(mockedWrited.Object);

            ConsoleRenderer renderer = new ConsoleRenderer();
            Scoreboard scoreBoard = new Scoreboard();
            IList<Player> players = new List<Player>();

            for (int i = 1; i <= 5; i++)
            {
                var player = new Player();
                player.Name = "TestName" + i;
                player.MoveCount = i;
                players.Add(player);
            }

            renderer.PrintScore(scoreBoard);

            mockedWrited.Verify(w => w.WriteLine(It.Is<string>(str => str.Contains("->"))), Times.Exactly(scoreBoard.Players.Count));
        }

        [TestMethod]
        public void TestRenderMessageToProceedAllPassedText()
        {
            var mockedWriter = new Mock<HelperWriter>();
            Console.SetOut(mockedWriter.Object);

            List<string> messageToProcess = new List<string>()
            {
               GameMassages.PlayAgainMessage,
               GameMassages.PressBackMessage,
               GameMassages.WelcomeMessage,
               GameMassages.WrongInputAndContinueMessage,
               GameMassages.WrongInputMessage,
               GameMassages.HowToPlayMessage,
               GameMassages.GoodByeMessage
            };

            ConsoleRenderer renderer = new ConsoleRenderer();
            messageToProcess.ForEach(msg => renderer.PrintMessage(msg));

            mockedWriter.Verify(w => w.WriteLine(It.Is<string>(str => messageToProcess.Contains(str))), Times.Exactly(messageToProcess.Count));
        }


    }
}