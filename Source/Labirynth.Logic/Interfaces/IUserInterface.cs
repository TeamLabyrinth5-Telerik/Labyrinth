namespace Labirynth.Logic.Interfaces
{
    using Labirynth.Common.Enums;

    public interface IUserInterface
    {
        string GetUserInput();

        Commands GetCommandFromInput();
    }
}
