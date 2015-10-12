namespace Labyrinth.Console.Interfaces
{
    using Labyrinth.Models;

    /// <summary>
    /// IGrid interface.
    /// </summary>
    public interface IGrid
    {
        /// <summary>
        /// Get or set game field
        /// </summary>
        char[,] Field { get; set; }

        /// <summary>
        /// Get or set total rows of grid
        /// </summary>
        int TotalRows { get; set; }

        /// <summary>
        /// Get or set total columns of grid
        /// </summary>
        int TotalCols { get; set; }

        /// <summary>
        /// Get certain cell of grid
        /// </summary>
        /// <param name="row">Current row</param>
        /// <param name="col">Current column</param>
        /// <returns></returns>
        char GetCell(int row, int col);

        /// <summary>
        /// Set certain cell of grid
        /// </summary>
        /// <param name="row">Current row</param>
        /// <param name="col">Current column</param>
        /// <param name="value">Current character</param>
        void SetCell(int row, int col, char value);

        /// <summary>
        /// Get certain cell of grid
        /// </summary>
        /// <param name="position">Cell position in the grid</param>
        /// <returns></returns>
        char GetCell(Position position);

        /// <summary>
        /// Set certain cell of grid
        /// </summary>
        /// <param name="position">Cell position</param>
        /// <param name="value">Current character</param>
        void SetCell(Position position, char value);
    }
}