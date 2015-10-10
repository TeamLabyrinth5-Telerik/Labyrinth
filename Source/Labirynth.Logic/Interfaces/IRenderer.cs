namespace Labyrinth.Logic.Interfaces
{
    using Labyrinth.Console.Interfaces;
    using Labyrinth.Models;

    public interface IRenderer
    {
        void PrintLabirynth(IGrid grid);

        void PrintScore(Scoreboard score);

        void PrintMessage(string message);

        void PrintMenu();

        void ClearConsole();
    }
}
