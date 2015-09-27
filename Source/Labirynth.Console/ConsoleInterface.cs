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
            Console.WriteLine(input.Key.ToString());
            return input.Key.ToString();
        }



        public Commands GetCommandFromInput()
        {
            string input = this.GetButtonInput().ToUpper();

            switch (input)
            {
                case GlobalConstants.ExitCommand:   
                    return Commands.Exit;
                case GlobalConstants.TopCommand:
                    return Commands.Top;
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
