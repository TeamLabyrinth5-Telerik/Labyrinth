namespace Labyrinth.Models.Interfaces
{
    using System;

    /// <summary>
    /// IPlayer interface.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Gets or sets player's name as a string.
        /// </summary>
        /// <value>The Name property gets or set's a player's name.</value>
        string Name { get; set; }

        /// <summary>
        /// Get or set player move count
        /// </summary>
        int MoveCount { get; set; }
        
        /// <summary>
        /// Ger or set player position
        /// </summary>
        Position Position { get; set; }
    }
}
