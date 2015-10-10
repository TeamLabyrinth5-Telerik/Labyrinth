namespace Labyrinth.Logic.Interfaces
{
    using Labyrinth.Console.Interfaces;
    using Labyrinth.Models.Interfaces;

    /// <summary>
    /// Interface for initializing the game
    /// </summary>
    public interface IInitializer
    {
        /// <summary>
        /// Initialize the game
        /// </summary>
        /// <param name="grid">The grid to be initialized</param>
        /// <param name="player">The player to be initialized</param>
        void InitializeGame(IGrid grid, IPlayer player);
    }
}
