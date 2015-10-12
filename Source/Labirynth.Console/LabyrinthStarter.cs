namespace Labyrinth.Console
{
    using System.Reflection;
    using Labyrinth.Logic.Interfaces;
    using Ninject;

    /// <summary>
    /// A normal game starter object implementing Facade design pattern.
    /// </summary>
    public class LabyrinthStarter
    {
        private static readonly object SyncRoot = new object();
        private static volatile LabyrinthStarter instance;

        private LabyrinthStarter()
        {
        }
      
        /// <summary>
        /// Gets a instance of the game <see cref="LabyrinthStarter"/> class.
        /// </summary>
        /// <value>Instance of a game starter.</value>
        public static LabyrinthStarter Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
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
        /// Start a new game
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