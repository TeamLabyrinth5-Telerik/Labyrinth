namespace Labyrinth.Logic.Interfaces
{
    using Labirynth.Console.Interfaces;
    using Labyrinth.Models;
    using Labyrinth.Models.Interfaces;

    public interface IInitializer
    {
        void InitializeGame(IGrid grid, IPlayer player);
    }
}
