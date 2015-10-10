namespace Labyrinth.Console
{
    using System.Reflection;
    using Labyrinth.Logic.Interfaces;
    using Ninject;

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
                        {
                            instance = new LabyrinthStarter();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Start the game
        /// </summary>
        public void StartGame()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var engine = kernel.Get<IEngine>();
            engine.Run();
        }
    }
}