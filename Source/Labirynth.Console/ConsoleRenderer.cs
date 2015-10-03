namespace Labyrinth.Console
{
    using System;
    using Labirynth.Console.Interfaces;
    using Labyrinth.Common;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Models;

    public class ConsoleRenderer : IRenderer
    {
        public void PrintLabirynth(IGrid grid)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  " + new string('─', GlobalConstants.GridRowsCount * 2 + 1));

            for (int row = 0; row < GlobalConstants.GridRowsCount; row++)
            {
                Console.Write("{0,2}", "|");
                for (int col = 0; col < GlobalConstants.GridColsCount; col++)
                {
                    Console.Write("{0,2}", grid.GetCell(row, col));
                }

                Console.Write("{0,2}", "|");
                Console.WriteLine();
            }

            Console.WriteLine("  " + new string('─', GlobalConstants.GridRowsCount * 2 + 1));
        }

        public void PrintScore(Scoreboard scoreBoard)
        {
            int counter = 1;

            if (scoreBoard.Players.Count <= 0)
            {
                Console.WriteLine(GameMassages.EmptyScoreBoardMessage);
            }

            foreach (var player in scoreBoard.Players)
            {
                Console.WriteLine("{0}| {1} --> {2}", counter, player.Name, player.MoveCount);
                counter++;
            }
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintMenu()
        {
            this.PrintOnPosition(16, 0, GlobalConstants.logo, ConsoleColor.Green);
            
            var text = "Please select: ";
            this.PrintOnPosition(GlobalConstants.LogoStartPositionX, GlobalConstants.LogoStartPositionY, text, ConsoleColor.White);

            var options = new string[] 
            {
                "New Game",
                "How to play",
                "High Scores",
                "Quit"
            };

            for (int i = 0; i < options.Length; i++)
            {
                this.PrintOnPosition(GlobalConstants.LogoStartPositionX, GlobalConstants.LogoStartPositionY + i + 1, i + 1 + ": ", ConsoleColor.Yellow);
                this.PrintOnPosition(GlobalConstants.LogoStartPositionX + 3, GlobalConstants.LogoStartPositionY + i + 1, options[i], ConsoleColor.Green);
            }

            this.PrintOnPosition(GlobalConstants.LogoStartPositionX, GlobalConstants.LogoStartPositionY + options.Length + 1, string.Empty);
        }

        public void PrintOnPosition(int x, int y, string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
        }

        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}