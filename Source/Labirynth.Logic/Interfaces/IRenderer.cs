namespace Labirynth.Logic.Interfaces
{
    using Labirynth.Models;

    public interface IRenderer
    {
        void PrintLabirynth(Grid grid);

        void PrintScore(Scoreboard score);

        void PrintMessage(string message);
    }
}
