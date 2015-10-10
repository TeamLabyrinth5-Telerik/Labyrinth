namespace Labyrinth.Console.Interfaces
{
    using System.Collections.Generic;
    using Labyrinth.Models;
    using Labyrinth.Models.Interfaces;

    public interface IGrid
    {
        char[,] Field { get; set; }

        int TotalRows { get; set; }

        int TotalCols { get; set; }

        char GetCell(int row, int col);

        void SetCell(int row, int col, char value);

        char GetCell(Position position);

        void SetCell(Position position, char value);
    }
}