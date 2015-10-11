namespace Labyrinth.Common
{
    public class GameMassages
    {
        public const string WelcomeMessage = "Welcome to “Labirinth” game. Please try to escape.";

        public const string HowToPlayMessage = " Press '1' to start a new game \n Press '3' to view the top scoreboard \n Press '4' to quit the game. \n Use UpArrow, DownArrow, LeftArrow and RigthArrow to navigate. \n Use S and L to Save and Load game state.";

        public const string InviteUserInputMessage = "Enter your move (L=left, R=right, U=up, D=down): ";

        public const string WrongInputMessage = "Invalid command!";

        public const string WrongInputAndContinueMessage = "Invalid Move!\n**Press Enter to continue**";

        public const string EnterNameMessage = "**Please put down your name:**";

        public const string WonGameMessage = "Congratulations! You've exited the labirynth in {0} moves.";

        public const string EmptyScoreBoardMessage = "The scoreboard is empty.";

        public const string GameSaved = "Game saved.";

        public const string GameLoaded = "Game loaded.";

        public const string LoadError = "There are no saved state.";

        public const string PlayAgainMessage = "Do you want to play again ?\nPlease choice Yes/No";

        public const string GoodByeMessage = "GoodBye {0}!";

        public const string PressBackMessage = "\nPress Backspace to go back";
    }
}
