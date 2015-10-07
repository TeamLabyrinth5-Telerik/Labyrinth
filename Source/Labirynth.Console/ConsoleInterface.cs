namespace Labyrinth.Console
{
    using System;
    using Labyrinth.Common;
    using Labyrinth.Common.Enums;
    using Labyrinth.Logic.Interfaces;

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
            Console.WriteLine(input);
            return input.Key.ToString();
        }

        /// <summary>
        /// Process input from the user.
        /// </summary>
        /// <returns>A <see cref="GameFifteen.Common.Enums.Command"/> to process.</returns>
        public Commands GetCommandFromInput()
        {
              string input = this.GetButtonInput().ToUpper();

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

        /// <summary>
        /// Method for ending game
        /// </summary>
        public void ExitGame()
        {
            Environment.Exit(0);
        }
    }
}
