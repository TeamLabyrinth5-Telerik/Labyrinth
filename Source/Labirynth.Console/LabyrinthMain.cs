using Labirynth.Console;
namespace Labyrinth.Console
{
    public class LabyrinthMain
    {
        public static void Main()
        {
            LabyrinthStarter gameStarter = LabyrinthStarter.Instance;
            gameStarter.StartGame();
        }
    }
}
