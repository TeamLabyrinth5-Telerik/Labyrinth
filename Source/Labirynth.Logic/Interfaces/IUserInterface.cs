namespace Labyrinth.Logic.Interfaces
{
    using Labyrinth.Common.Enums;

    public interface IUserInterface
    {
        string GetUserInput();

		void ExitGame();
		
        Commands GetCommandFromInput();
    }
}