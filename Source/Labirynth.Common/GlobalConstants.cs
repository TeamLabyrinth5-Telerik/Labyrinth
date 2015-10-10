namespace Labyrinth.Common
{
    public class GlobalConstants
    {
        public const int DefaultGridColsCount = 7;
        public const int DefaultGridRowsCount = 7;
        public const int MaximalGridColsCount = 15;
        public const int MaximalGridRowsCount = 15;

        public const int StartPlayerPositionX = 3;
        public const int StartPlayerPositionY = 3;
        public const int LogoStartPositionX = 33;
        public const int LogoStartPositionY = 10;
        public const int MinimumPercentageOfBlockedCells = 30;
        public const int MaximumPercentageOfBlockedCells = 50;

        public const char BlockedCellSymbol = '\u2592';
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
        public const string LevelA = "A";
        public const string LevelB = "B";
        public const string LevelC = "C";

        public const string Logo = @" _           _                _       _   _     
                | |         | |              (_)     | | | |    
                | |     __ _| |__  _   _ _ __ _ _ __ | |_| |__  
                | |    / _` | '_ \| | | | '__| | '_ \| __| '_ \ 
                | |___| (_| | |_) | |_| | |  | | | | | |_| | | |
                \_____/\__,_|_.__/ \__, |_|  |_|_| |_|\__|_| |_|
                                    __/ |                       
                                   |___/                        ";
    }
}
