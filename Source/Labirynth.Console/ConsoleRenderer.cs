namespace Labyrinth.Console
{
    using System;
    using Labyrinth.Common;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Models;
    using Labirynth.Console.Interfaces;

    public class ConsoleRenderer : IRenderer
    {
        public void PrintLabirynth(IGrid grid)
        {
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
            Console.CursorVisible = true;
            Console.CursorSize = 100;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1.Start Game");
            Console.WriteLine("2.How to play");
            Console.WriteLine("3.High Score");
            Console.WriteLine("4.Exit");
        }

        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}
