namespace Labyrinth.Models
{
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
