namespace Labirynth.Console
{
    using Labirynth.Logic;
    using Labirynth.Logic.Interfaces;
    using Labirynth.Models;

    public class LabirynthMain
    {
        public static void Main()
        {
            IUserInterface userInterface = new ConsoleInterface();
            IRenderer renderer = new ConsoleRenderer();
            IInitializer initializer = new Initializer();

            Engine engine = new Engine(renderer, userInterface, initializer);
            engine.Run();
        }
    }
}
