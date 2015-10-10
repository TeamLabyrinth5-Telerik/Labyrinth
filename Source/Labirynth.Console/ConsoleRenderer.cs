namespace Labyrinth.Console
{
    using System;
    using Labyrinth.Common;
    using Labyrinth.Console.Interfaces;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Models;

    public class ConsoleRenderer : IRenderer
    {
        /// <summary>
        /// Prints the labyrinth to the console
        /// </summary>
        /// <param name="grid">the playfield</param>
        public void PrintLabirynth(IGrid grid)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" " + new string('\u2593', (grid.TotalRows * 2) + 3));

            for (int row = 0; row < grid.TotalRows; row++)
            {
                Console.Write("{0,2}", "\u2593");
                for (int col = 0; col < grid.TotalCols; col++)
                {
                    Console.Write("{0,2}", grid.GetCell(row, col));
                }

                Console.Write("{0,2}", "\u2593");
                Console.WriteLine();
            }

            Console.WriteLine(" " + new string('\u2593', (grid.TotalCols * 2) + 3));
        }

        /// <summary>
        /// Prints high score on the console
        /// </summary>
        /// <param name="scoreBoard">IList where is saved scores</param>
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

        /// <summary>
        /// Prints a message to the console
        /// </summary>
        /// <param name="message">Printed value</param>
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Prints Menu to the console
        /// </summary>
        public void PrintMenu()
        {
            this.PrintOnPosition(16, 0, GlobalConstants.Logo, ConsoleColor.Green);

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

        /// <summary>
        /// Prints to the console on choosen position
        /// </summary>
        /// <param name="x">X coord of the console</param>
        /// <param name="y">Y coord of the console</param>
        /// <param name="text">Value to be printed</param>
        /// <param name="color">Color of the printed text</param>
        public void PrintOnPosition(int x, int y, string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
        }

        /// <summary>
        /// Clears the console
        /// </summary>
        public void ClearConsole()
        {
            Console.Clear();
        }

        /// <summary>
        /// Prints levels to console
        /// </summary>
        public void PrintLevels()
        {
            this.PrintOnPosition(16, 0, GlobalConstants.Logo, ConsoleColor.Green);

            var text = "Please select level: ";
            this.PrintOnPosition(GlobalConstants.LogoStartPositionX, GlobalConstants.LogoStartPositionY, text, ConsoleColor.White);

            var options = new string[]
           {
                "7 x 7",
                "10 x 10",
                "15 x 15",
           };

            for (int i = 0; i < options.Length; i++)
            {
                this.PrintOnPosition(GlobalConstants.LogoStartPositionX, GlobalConstants.LogoStartPositionY + i + 1, (char)(65 + i) + ": ", ConsoleColor.Yellow);
                this.PrintOnPosition(GlobalConstants.LogoStartPositionX + 3, GlobalConstants.LogoStartPositionY + i + 1, options[i], ConsoleColor.Green);
            }

            this.PrintOnPosition(GlobalConstants.LogoStartPositionX, GlobalConstants.LogoStartPositionY + options.Length + 1, string.Empty);
        }
    }
}