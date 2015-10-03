namespace Labirynth.Logic
{
    using Labirynth.Logic.Interfaces;
    using Labyrinth.Logic.Interfaces;

    public abstract class Engine : IEngine
    {
        protected readonly IInitializer initializer;

        protected Engine(IInitializer initializer)
        {
            this.initializer = initializer;
        }

        public abstract void Run();
    }
}