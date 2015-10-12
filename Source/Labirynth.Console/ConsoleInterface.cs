namespace Labyrinth.Console
{
    using System;
    using Labyrinth.Common;
    using Labyrinth.Common.Enums;
    using Labyrinth.Logic.Interfaces;

    /// <summary>
    /// Interacts with console user, process commands.
    /// </summary>
    public class ConsoleInterface : IUserInterface
    {
        /// <summary>
        /// Gets the input text from the user.
        /// </summary>
        /// <returns>The input as <see cref="System.String"/></returns>
        public string GetUserInput()
        {
            var input = Console.ReadLine();
            return input;
        }

        /// <summary>
        /// Get user input from keyboard
        /// </summary>
        public string GetButtonInput()
        {
            var input = Console.ReadKey();
            return input.Key.ToString().ToUpper();
        }

        /// <summary>
        ///  Process input from the user.
        /// </summary>
        /// <returns>Command for execute</returns>
        public Commands GetCommandFromInput()
        {
              string input = this.GetButtonInput();

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
                case GlobalConstants.UpKeyCommand:
                    return Commands.MoveUp;
                case GlobalConstants.DownKeyCommand:
                    return Commands.MoveDown;
                case GlobalConstants.LeftKeyCommand:
                    return Commands.MoveLeft;
                case GlobalConstants.RigthKeyCommand:
                    return Commands.MoveRight;
                case GlobalConstants.LevelA:
                    return Commands.LevelA;
                case GlobalConstants.LevelB:
                    return Commands.LevelB;
                case GlobalConstants.LevelC:
                    return Commands.LevelC;
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

        /// <summary>
        /// Method for ending game
        /// </summary>
        public void ExitGame()
        {
            Environment.Exit(0);
        }
    }
}
