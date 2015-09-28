namespace Labyrinth.Models
{
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