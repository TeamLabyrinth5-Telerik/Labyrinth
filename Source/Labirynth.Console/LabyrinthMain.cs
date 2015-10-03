namespace Labyrinth.Console
{
    using Labyrinth.Logic;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Models;

    public class LabyrinthMain
    {
        public static void Main()
        {
            IUserInterface userInterface = new ConsoleInterface();
            IRenderer renderer = new ConsoleRenderer();
            IInitializer initializer = new Initializer();

            LabyrinthEngine engine = new LabyrinthEngine(renderer, userInterface, initializer);
            engine.Run();
        }
    }
}
