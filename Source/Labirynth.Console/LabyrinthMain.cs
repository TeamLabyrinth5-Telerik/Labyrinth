namespace Labyrinth.Console
{
    /// <summary>
    /// The main object where game starts.
    /// </summary>
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
