namespace Labirynth.Console.Interfaces
{
    using Labyrinth.Models;
    using Labyrinth.Models.Interfaces;
    using System.Collections.Generic;

    public interface IGrid
    {
        char[,] Field { get; set; }

        int TotalRows { get; }

        int TotalCols { get; }

        char GetCell(int row, int col);

        void SetCell(int row, int col, char value);

        char GetCell(Position position);

        void SetCell(Position position, char value);
    }
}