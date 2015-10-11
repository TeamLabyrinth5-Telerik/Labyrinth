namespace Labyrinth.Logic.Interfaces
{
    using Labyrinth.Common.Enums;

    /// <summary>
    /// Provides interacting with user methods.
    /// </summary>
    public interface IUserInterface
    {
        /// <summary>
        /// Retrieves the user input.
        /// </summary>
        /// <returns>User input as string.</returns>
        string GetUserInput();

        /// <summary>
        /// Retrieves the user input.
        /// </summary>
        /// <returns>User input as pressed key.</returns>
        string GetButtonInput();

        /// <summary>
        /// Exit game
        /// </summary>
        void ExitGame();

        /// <summary>
        /// Return command for execute
        /// </summary>
        /// <returns></returns>
        Commands GetCommandFromInput();
    }
}