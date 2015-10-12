namespace Labyrinth.Models
{
    /// <summary>
    /// Memento design pattern
    /// The 'Memento' class
    /// </summary>
    public class Memento
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Memento" /> class
        /// </summary>
        /// <param name="grid">Grid to be saved in memento</param>
        /// <param name="position">Player to be saved in memento</param>
        public Memento(char[,] grid, Position position)
        {
            this.Field = grid;
            this.Position = position;
        }

        /// <summary>
        /// Get or set field in memento
        /// </summary>
        public char[,] Field { get; set; }

        /// <summary>
        /// Get ot set player position in memento
        /// </summary>
        public Position Position { get; set; }
    }
}