namespace Labyrinth.Common
{
    public class GlobalConstants
    {
        public const int GridColsCount = 7;
        public const int GridRowsCount = 7;
        public const int StartPlayerPositionX = 3;
        public const int StartPlayerPositionY = 3;

        public const char BlockedCellSymbol = 'X';
        public const char FreeCellSymbol = '-';
        public const char PlayerSignSymbol = '*';

        public const string ExitCommand = "EXIT";
        public const string RestartCommand = "RESTART";

        public const string UpKeyCommand = "UPARROW";
        public const string DownKeyCommand = "DOWNARROW";
        public const string LeftKeyCommand = "LEFTARROW";
        public const string RigthKeyCommand = "RIGHTARROW";

        public const string InvalidCommand = "Invalid command!";
        public const string SaveCommand = "S";
        public const string LoadCommand = "L";
        public const string StartCommand = "D1";
        public const string HowToPlayCommand = "D2";
        public const string HighScoreCommand = "D3";
        public const string Exit = "D4";

        public const int MinimumPercentageOfBlockedCells = 30;
        public const int MaximumPercentageOfBlockedCells = 50;
    }
}
