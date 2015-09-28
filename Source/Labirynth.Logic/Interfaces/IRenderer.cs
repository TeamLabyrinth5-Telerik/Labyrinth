namespace Labyrinth.Logic.Interfaces
{
    using Labyrinth.Models;

    public interface IRenderer
    {
        void PrintLabirynth(Grid grid);

        void PrintScore(Scoreboard score);

        void PrintMessage(string message);

        void ClearConsole();
    }
}
