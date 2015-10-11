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

        /// <summary>
        /// Generate game field 
        /// </summary>
        /// <param name="player">Current player</param>
        /// <param name="grid">Current game matrix</param>
        /// <returns></returns>
        IGrid GenerateGrid(IPlayer player, IGrid grid);

        /// <summary>
        /// Make at least one out of the maze
        /// </summary>
        /// <param name="generatedGrid">Genereted game field</param>
        /// <param name="player">Current player</param>
        void MakeAtLeastOneExitReachable(IGrid generatedGrid, IPlayer player);
    }
}
