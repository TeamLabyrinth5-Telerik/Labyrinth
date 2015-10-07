namespace Labyrinth.Models
{
    /// <summary>
    /// Class GridMemory represent CareTaker for Memento design pattern
    /// </summary>
    public class GridMemory
    {
        private Memento memento;

        public Memento Memento
        {
            get
            {
                return this.memento;
            }

            set
            {
                this.memento = value;
            }
        }
    }
}
