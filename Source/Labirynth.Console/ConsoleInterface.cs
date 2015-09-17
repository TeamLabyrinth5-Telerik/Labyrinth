namespace Labirynth.Console
{
    using System;
    using Labirynth.Common;
    using Labirynth.Common.Enums;
    using Labirynth.Logic.Interfaces;

    public class ConsoleInterface : IUserInterface
    {
        public string GetUserInput()
        {
            var input = Console.ReadLine();
            return input;
        }

        public Commands GetCommandFromInput()
        {
            string input = this.GetUserInput().ToUpper();

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
    }
}
