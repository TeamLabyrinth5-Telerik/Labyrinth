namespace Labyrinth.Models
{
    public class Memento
    {
        public Memento(char[,] grid)
        {
            this.Field = grid;
        }

        public char[,] Field { get; set; }
    }
}
