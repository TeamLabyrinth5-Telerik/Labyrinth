namespace Labyrinth.Console
{
    using System;
    using Labyrinth.Common;
    using Labyrinth.Common.Enums;
    using Labyrinth.Logic.Interfaces;

    public class ConsoleInterface : IUserInterface
    {
        public string GetUserInput()
        {
            var input = Console.ReadLine();
            return input;
        }

        public string GetButtonInput()
        {
            var input = Console.ReadKey();
            return input.Key.ToString();
        }

        public Commands GetCommandFromInput()
        {
            string input = this.GetUserInput().ToUpper();

            switch (input)
            {
                case GlobalConstants.ExitCommand:
                    return Commands.Exit;
                case GlobalConstants.Exit:
                    return Commands.Exit;
                case GlobalConstants.HighScoreCommand:
                    return Commands.HighScore;
                case GlobalConstants.RestartCommand:
                    return Commands.Restart;
                case GlobalConstants.UpCommand:
                    return Commands.U;
                case GlobalConstants.DownCommand:
                    return Commands.D;
                case GlobalConstants.LeftCommand:
                    return Commands.L;
                case GlobalConstants.RigthCommand:
                    return Commands.R;
                case GlobalConstants.UpKeyCommand:
                    return Commands.U;
                case GlobalConstants.DownKeyCommand:
                    return Commands.D;
                case GlobalConstants.LeftKeyCommand:
                    return Commands.L;
                case GlobalConstants.RigthKeyCommand:
                    return Commands.R;
                case GlobalConstants.SaveCommand:
                    return Commands.Save;
                case GlobalConstants.LoadCommand:
                    return Commands.Load;
                case GlobalConstants.StartCommand:
                    return Commands.Start;
                case GlobalConstants.HowToPlayCommand:
                    return Commands.HowTo;
                default:
                    return Commands.Invalid;
            }
        }

        public void ExitGame()
        {
            Environment.Exit(0);
        }
    }
}
