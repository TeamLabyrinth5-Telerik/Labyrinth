namespace Labyrinth.Models
{
    using Labyrinth.Common;

    public class Grid
    {
        private char[,] grid;

        public Grid(int rows = GlobalConstants.GridRowsCount, int cols = GlobalConstants.GridColsCount)
        {
            this.TotalRows = rows;
            this.TotalCols = cols;
            this.grid = new char[rows, cols];
        }

        public int TotalRows { get; private set; }

        public int TotalCols { get; private set; }

        public char GetCell(int row, int col)
        {
            return this.grid[row, col];
        }

        public void SetCell(int row, int col, char value)
        {
            this.grid[row, col] = value;
        }

        public char GetCell(Position position)
        {
            return this.grid[position.X, position.Y];
        }

        public void SetCell(Position position, char value)
        {
            this.grid[position.X, position.Y] = value;
        }
    }
}
