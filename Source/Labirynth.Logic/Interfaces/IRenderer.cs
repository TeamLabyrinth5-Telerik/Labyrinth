namespace Labyrinth.Logic.Interfaces
{
    using Labyrinth.Console.Interfaces;
    using Labyrinth.Models;

    /// <summary>
    /// Interface for rendering object
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Render labyrint
        /// </summary>
        /// <param name="grid">The labyrint to be rendered</param>
        void PrintLabirynth(IGrid grid);

        /// <summary>
        /// Render scoreboard
        /// </summary>
        /// <param name="score">The scoreboard to be rendered</param>
        void PrintScore(Scoreboard score);

        /// <summary>
        /// Render a message
        /// </summary>
        /// <param name="message">The message to be rendered</param>
        void PrintMessage(string message);

        /// <summary>
        /// Renders a menu
        /// </summary>
        void PrintMenu();

        /// <summary>
        /// Renderes game levels
        /// </summary>
        void PrintLevels();

        /// <summary>
        /// Clears the console
        /// </summary>
        void ClearConsole();
    }
}
