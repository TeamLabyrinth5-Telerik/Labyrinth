namespace Labirynth.Console
{
    using System;
    using System.Collections.Generic;
    using Labirynth.Common;
    using Labirynth.Logic.Interfaces;
    using Labirynth.Models;

    public class ConsoleRenderer : IRenderer
    {
        public void PrintLabirynth(Grid grid)
        {
            for (int row = 0; row < GlobalConstants.GridRowsCount; row++)
            {
                for (int col = 0; col < GlobalConstants.GridColsCount; col++)
                {
                    Console.Write("{0,2}", grid.GetCell(row, col));
                }

                Console.WriteLine();
            }
        }

        public void PrintScore(Scoreboard scoreBoard)
        {
            int counter = 1;

            foreach (var player in scoreBoard.Players)
            {
                Console.WriteLine("{0}. {1} --> {2}",counter, player.Name, player.MoveCount);
                counter++;
            }
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
