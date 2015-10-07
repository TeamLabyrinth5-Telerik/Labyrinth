namespace Labyrinth.Models
{
    /// <summary>
    /// Memento design pattern
    /// The 'Memento' class
    /// </summary>
    public class Memento
    {
        public Memento(char[,] grid, Position position)
        {
            this.Field = grid;
            this.Position = position;
        }

        public char[,] Field { get; set; }

        public Position Position { get; set; }
    }
}