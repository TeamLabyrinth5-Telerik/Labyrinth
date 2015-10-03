namespace Labyrinth.Models
{
    using Labirynth.Console.Interfaces;
    using Labyrinth.Common;

    public class Grid : IGrid
    {
        public Grid(int rows = GlobalConstants.GridRowsCount, int cols = GlobalConstants.GridColsCount)
        {
            this.TotalRows = rows;
            this.TotalCols = cols;
            this.Field = new char[rows, cols];
        }

        public char[,] Field { get; set; }

        public int TotalRows { get; private set; }

        public int TotalCols { get; private set; }

        public char GetCell(int row, int col)
        {
            return this.Field[row, col];
        }

        public void SetCell(int row, int col, char value)
        {
            this.Field[row, col] = value;
        }

        public char GetCell(Position position)
        {
            return this.Field[position.X, position.Y];
        }

        public void SetCell(Position position, char value)
        {
            this.Field[position.X, position.Y] = value;
        }
    }
}
