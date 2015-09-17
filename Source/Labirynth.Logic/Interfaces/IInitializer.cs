namespace Labirynth.Logic.Interfaces
{
    using Labirynth.Models;
    using Labirynth.Models.Interfaces;

    public interface IInitializer
    {
        void InitializeGame(Grid grid, IPlayer player);
    }
}
