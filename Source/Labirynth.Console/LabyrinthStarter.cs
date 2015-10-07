namespace Labirynth.Console
{
    using Labirynth.Logic.Interfaces;
    using Ninject;
    using System.Reflection;

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
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var engine = kernel.Get<IEngine>();
             engine.Run();
        }
    }
}