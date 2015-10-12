namespace Labyrinth.Models
{
    /// <summary>
    /// Class GridMemory represent CareTaker for Memento design pattern
    /// </summary>
    public class GridMemory
    {
        /// <summary>
        /// Field of memento instance
        /// </summary>
        private Memento memento;

        /// <summary>
        /// Gets or sets memento.
        /// </summary>
        /// <value>Memento that stores game states when the player saves their game.</value>
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
