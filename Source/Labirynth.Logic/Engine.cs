namespace Labyrinth.Logic
{
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Logic.Interfaces;

    public abstract class Engine : IEngine
    {
        protected readonly IInitializer Initializer;

        protected Engine(IInitializer initializer)
        {
            this.Initializer = initializer;
        }

        public abstract void Run();
    }
}