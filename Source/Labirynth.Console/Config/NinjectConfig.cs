namespace Labyrinth.Console.Config
{
    using Labyrinth.Console;
    using Labyrinth.Console.Interfaces;
    using Labyrinth.Logic;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Models;
    using Labyrinth.Models.Interfaces;
    using Ninject.Modules;

    /// <summary>
    /// Dependency injection
    /// Binds interfaces to concrete implementations.
    /// </summary>
    public class NinjectConfig : NinjectModule
    {
        /// <summary>
        /// Binds interfaces to concrete implementations.
        /// </summary>
        public override void Load()
        {
            Bind<IUserInterface>().To<ConsoleInterface>();
            Bind<IInitializer>().To<Initializer>();
            Bind<IRenderer>().To<ConsoleRenderer>();
            Bind<IGrid>().To<Grid>();
            Bind<IPlayer>().To<Player>();
            Bind<IEngine>().To<LabyrinthEngine>();
        }
    }
}