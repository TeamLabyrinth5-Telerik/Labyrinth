namespace Labirynth.Console
{
    using Labirynth.Console.Interfaces;
    using Labyrinth.Common;
    using Labyrinth.Console;
    using Labyrinth.Logic;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Models;
    using Labyrinth.Models.Interfaces;

    public class LabyrinthStarter
    {
        private static volatile LabyrinthStarter instance;
        private static object syncRoot = new object();

        private LabyrinthStarter()
        {
        }

        public static LabyrinthStarter Instance
        {
            get 
            {
                if (instance == null) 
                {
                    lock (syncRoot) 
                    {
                        if (instance == null)
                            instance = new LabyrinthStarter();
                    }
                }

                return instance;
            }
        }

        public void StartGame()
        {
            IUserInterface userInterface = new ConsoleInterface();
            IRenderer renderer = new ConsoleRenderer();
            IInitializer initializer = new Initializer();
            IPlayer player = new Player();
            IGrid grid = new Grid();

            LabyrinthEngine engine = new LabyrinthEngine(renderer, userInterface, initializer, player, grid);
            engine.Run();
        }
    }
}