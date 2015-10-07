namespace Labyrinth.Models
{
    using Labirynth.Console.Interfaces;
    using Labyrinth.Common;

    /// <summary>
    /// Memento design pattern
    /// The 'Originator' class
    /// </summary>
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

        /// <summary>
        /// Get value from certain cell from playfield
        /// </summary>
        /// <param name="row">The value of current row</param>
        /// <param name="col">The value current col</param>
        /// <returns></returns>
        public char GetCell(int row, int col)
        {
            return this.Field[row, col];
        }

        /// <summary>
        /// Set value from certain cell from playfield
        /// </summary>
        /// <param name="row">The value of current row</param>
        /// <param name="col">The value current col</param>
        /// <param name="value">The value of the char to set</param>
        public void SetCell(int row, int col, char value)
        {
            this.Field[row, col] = value;
        }

        /// <summary>
        /// Get value from certain cell from playfield
        /// </summary>
        /// <param name="position">The position of current cell</param>
        /// <returns></returns>
        public char GetCell(Position position)
        {
            return this.Field[position.X, position.Y];
        }

        /// <summary>
        /// Set value from certain cell to playfield
        /// </summary>
        /// <param name="position">The position of current cell</param>
        /// <param name="value">The value of the char to set</param>
        public void SetCell(Position position, char value)
        {
            this.Field[position.X, position.Y] = value;
        }
    }
}
