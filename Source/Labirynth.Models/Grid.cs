﻿namespace Labyrinth.Models
{
    using Labyrinth.Common;
    using Labyrinth.Console.Interfaces;

    /// <summary>
    /// Memento design pattern
    /// The 'Originator' class
    /// </summary>
    public class Grid : IGrid
    {
        /// <summary>
        /// nitializes a new instance of the Grid
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public Grid(int rows = GlobalConstants.MaximalGridRowsCount, int cols = GlobalConstants.MaximalGridColsCount)
        {
            this.TotalRows = rows;
            this.TotalCols = cols;
            this.Field = new char[this.TotalRows, this.TotalCols];
        }

        /// <summary>
        /// Get or set field
        /// </summary>
        public char[,] Field { get; set; }

        /// <summary>
        /// Get or set total rows of grid
        /// </summary>
        public int TotalRows { get; set; }

        /// <summary>
        /// Get or set total cols of grid
        /// </summary>
        public int TotalCols { get; set; }

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
