namespace Labyrinth.Common
{
    public class GameMassages
    {
        public const string WelcomeMessage = "Welcome to “Labirinth” game. Please try to escape.";

        public const string HowToPlayMessage = " Press '1' to start a new game \n Press '3' to view the top scoreboard \n Press '4' to quit the game. \n Use U, D, L, R (up, down, left, right) to navigate";

        public const string InviteUserInputMessage = "Enter your move (L=left, R-right, U=up, D=down): ";

        public const string WrongInputMessage = "Invalid command!";

        public const string WrongInputAndContinueMessage = "Invalid Command!\n**Press Enter to continue**";

        public const string EnterNameMessage = "**Please put down your name:**";

        public const string WonGameMessage = "Congratulations! You've exited the labirynth in {0} moves.";

        public const string EmptyScoreBoardMessage = "The scoreboard is empty.";

        public const string GameSaved = "Game saved.";

        public const string GameLoaded = "Game loaded.";

        public const string LoadError = "There are no saved state.";
    }
}
