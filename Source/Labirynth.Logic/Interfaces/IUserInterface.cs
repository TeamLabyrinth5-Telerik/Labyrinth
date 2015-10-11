namespace Labyrinth.Logic.Interfaces
{
    using Labyrinth.Common.Enums;

    public interface IUserInterface
    {
        string GetUserInput();

        string GetButtonInput();

        void ExitGame();

        Commands GetCommandFromInput();
    }
}