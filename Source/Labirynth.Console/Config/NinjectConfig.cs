namespace Labirynth.Console.Config
{
    using Ninject.Modules;
    using Labyrinth.Logic.Interfaces;
    using Labirynth.Console.Interfaces;
    using Labyrinth.Models.Interfaces;
    using Labirynth.Logic.Interfaces;
    using Labyrinth.Console;
    using Labyrinth.Logic;
    using Labyrinth.Models;
    
    public class NinjectConfig : NinjectModule
    {
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