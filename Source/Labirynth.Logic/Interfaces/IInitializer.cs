namespace Labyrinth.Logic.Interfaces
{
    using Labyrinth.Models;
    using Labyrinth.Models.Interfaces;

    public interface IInitializer
    {
        void InitializeGame(Grid grid, IPlayer player);
    }
}
