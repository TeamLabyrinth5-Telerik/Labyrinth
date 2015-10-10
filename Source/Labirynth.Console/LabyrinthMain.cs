namespace Labyrinth.Console
{
    using Labyrinth.Console;

    public class LabyrinthMain
    {
        /// <summary>
        /// Start point of the application
        /// </summary>
        public static void Main()
        {
            LabyrinthStarter gameStarter = LabyrinthStarter.Instance;
            gameStarter.StartGame();
        }
    }
}
