namespace Labyrinth.Logic
{
    using System;
    using Labyrinth.Common;
    using Labyrinth.Common.Enums;
    using Labyrinth.Console.Interfaces;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Models;
    using Labyrinth.Models.Interfaces;

    /// <summary>
    /// The game engine - the entire game logic.
    /// </summary>
    public class LabyrinthEngine : Engine, IEngine
    {
        /// <summary>
        /// The field that holds the IRenderer instance which draws the game.
        /// </summary>
        private readonly IRenderer renderer;

        /// <summary>
        /// The field that holds the IUserInterface instance which reads user input.
        /// </summary>
        private readonly IUserInterface userInterface;

        /// <summary>
        /// The field that holds the GridMemory instance, represent CareTaker for Memento design pattern
        /// </summary>
        private readonly GridMemory gridMemory;

        /// <summary>
        /// The field that holds the Scoreboard instance, store player top scores
        /// </summary>
        private readonly Scoreboard scoreBoard;

        /// <summary>
        /// The field that holds the IPlayer instance.
        /// </summary>
        private IPlayer player;

        /// <summary>
        /// The field that holds the IGrid instance.
        /// </summary>
        private IGrid grid;

        /// <summary>
        /// Flag for game state
        /// </summary>
        private bool isGameOver;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabyrinthEngine" /> class.
        /// </summary>
        /// <param name="renderer">>Object to print.</param>
        /// <param name="userInterface">Interacting with user.</param>
        /// <param name="initializer">Initializing the game.</param>
        /// <param name="player">The player</param>
        /// <param name="grid">The play field</param>
        public LabyrinthEngine(IRenderer renderer, IUserInterface userInterface, IInitializer initializer, IPlayer player, IGrid grid)
            : base(initializer)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.scoreBoard = new Scoreboard();
            this.player = player;
            this.grid = grid;
            this.gridMemory = new GridMemory();
        }

        /// <summary>
        /// Start the game
        /// </summary>
        public override void Run()
        {
            while (true)
            {
                this.renderer.PrintMenu();
                var command = this.userInterface.GetCommandFromInput();
                this.renderer.ClearConsole();
                this.ExecuteCommand(command);
                this.renderer.ClearConsole();
            }
        }

        /// <summary>
        /// Execute commands.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        private void ExecuteCommand(Commands command)
        {
            switch (command)
            {
                case Commands.LevelA:
                    this.renderer.ClearConsole();
                    this.ProcessStartGameCommand(GlobalConstants.LevelAGridSize);
                    break;
                case Commands.LevelB:
                    this.renderer.ClearConsole();
                    this.ProcessStartGameCommand(GlobalConstants.LevelBGridSize);
                    break;
                case Commands.LevelC:
                    this.renderer.ClearConsole();
                    this.ProcessStartGameCommand(GlobalConstants.LevelCGridSize);
                    break;
                case Commands.MoveLeft:
                    this.renderer.ClearConsole();
                    this.ProcessMoveCommand(0, -1);
                    break;
                case Commands.MoveRight:
                    this.renderer.ClearConsole();
                    this.ProcessMoveCommand(0, 1);
                    break;
                case Commands.MoveUp:
                    this.renderer.ClearConsole();
                    this.ProcessMoveCommand(-1, 0);
                    break;
                case Commands.MoveDown:
                    this.renderer.ClearConsole();
                    this.ProcessMoveCommand(1, 0);
                    break;
                case Commands.Save:
                    this.renderer.ClearConsole();
                    this.ProcessSaveCommand();
                    break;
                case Commands.Load:
                    this.renderer.ClearConsole();
                    this.ProcessLoadCommand();
                    break;
                case Commands.HighScore:
                    this.ProcessPrintScoreCommand();
                    break;
                case Commands.Exit:
                    this.ProcessExitCommand();
                    break;
                case Commands.Invalid:
                    this.ProcessInvalidCommand();
                    break;
                case Commands.Start:
                    this.ProcessStartCommand();
                    break;
                case Commands.HowTo:
                    this.ProcessHowToCommand();
                    break;
                default:
                    this.renderer.PrintMessage(GameMassages.WrongInputAndContinueMessage);
                    this.userInterface.GetUserInput();
                    break;
            }
        }

        /// <summary>
        /// Implementation of "HowTo" command
        /// </summary>
        private void ProcessHowToCommand()
        {
            this.renderer.PrintMessage(GameMassages.HowToPlayMessage);
            this.GoBackToInitialMenu();
        }

        /// <summary>
        /// Implementation of "Save" command
        /// </summary>
        private void ProcessSaveCommand()
        {
            this.gridMemory.Memento = this.SaveMemento();
            this.renderer.PrintMessage(GameMassages.GameSaved);
        }

        /// <summary>
        /// Implementation of "Load" command
        /// </summary>
        private void ProcessLoadCommand()
        {
            try
            {
                this.RestoreMemento(this.gridMemory.Memento);
                this.renderer.PrintMessage(GameMassages.GameLoaded);
            }
            catch (NullReferenceException)
            {
                this.renderer.PrintMessage(GameMassages.LoadError);
            }
        }

        /// <summary>
        /// Implementation of "RestartGame" command
        /// </summary>
        private void ProcessRestartGameCommand(int size)
        {
            this.isGameOver = false;
            this.player = new Player();
            this.grid = new Grid(size);
            this.grid.TotalRows = size;
            this.grid.TotalCols = size;
            this.Initializer.InitializeGame(this.grid, this.player);
        }

        /// <summary>
        /// Implementation of "PrintScore" command
        /// </summary>
        private void ProcessPrintScoreCommand()
        {
            this.renderer.PrintScore(this.scoreBoard);
            this.GoBackToInitialMenu();
        }

        /// <summary>
        /// Implementation of "Invalid" command
        /// </summary>
        private void ProcessInvalidCommand()
        {
            this.renderer.PrintMessage(GameMassages.WrongInputMessage);
            this.userInterface.GetButtonInput();
            this.renderer.ClearConsole();
        }

        /// <summary>
        /// Implementation of "Move" command
        /// </summary>
        /// <param name="dirX">Horizontal direction</param>
        /// <param name="dirY">Vertical direction</param>
        private void ProcessMoveCommand(int dirX, int dirY)
        {
            this.player.MoveCount++;

            if (this.IsMoveValid(new Position(this.player.Position.X + dirX, this.player.Position.Y + dirY), this.grid) == false)
            {
                return;
            }

            if (this.grid.GetCell(this.player.Position.X + dirX, this.player.Position.Y + dirY) == GlobalConstants.BlockedCellSymbol)
            {
                // this.renderer.PrintMessage(GameMassages.WrongInputAndContinueMessage);
                // this.renderer.ClearConsole();
                //  this.userInterface.GetButtonInput();
                this.player.MoveCount--;
                return;
            }
            else
            {
                this.grid.SetCell(this.player.Position.X, this.player.Position.Y, GlobalConstants.FreeCellSymbol);
                this.grid.SetCell(this.player.Position.X + dirX, this.player.Position.Y + dirY, GlobalConstants.PlayerSignSymbol);
                this.player.Position = new Position(this.player.Position.X + dirX, this.player.Position.Y + dirY);
                return;
            }
        }

        /// <summary>
        /// Implementation of "Exit" command
        /// </summary>
        private void ProcessExitCommand()
        {
            this.userInterface.ExitGame();
        }

        /// <summary>
        /// Implementation of "StartGame" command
        /// </summary>
        /// <param name="size">Size of game field</param>
        private void ProcessStartGameCommand(int size)
        {
            this.player = new Player();
            this.grid = new Grid(size);
            this.grid.TotalRows = size;
            this.grid.TotalCols = size;
            this.Initializer.InitializeGame(this.grid, this.player);

            while (true)
            {
                if (this.isGameOver)
                {
                    this.renderer.PrintLabirynth(this.grid);
                    this.renderer.PrintMessage(string.Format(GameMassages.WonGameMessage, this.player.MoveCount));
                    this.SaveScore();
                    this.renderer.ClearConsole();

                    this.renderer.PrintMessage(GameMassages.PlayAgainMessage);
                    var answer = this.userInterface.GetUserInput().ToUpper();

                    if (answer == "NO")
                    {
                        this.renderer.ClearConsole();
                        this.renderer.PrintMessage(string.Format(GameMassages.GoodByeMessage, this.player.Name));

                        this.GoBackToInitialMenu();
                        this.isGameOver = false;
                        break;
                    }
                    else if (answer == "YES")
                    {
                        this.renderer.ClearConsole();
                        this.isGameOver = false;
                        this.ProcessRestartGameCommand(size);
                    }
                    else
                    {
                        this.renderer.ClearConsole();
                        this.ProcessInvalidCommand();
                        this.GoBackToInitialMenu();
                        this.ProcessRestartGameCommand(size);
                        this.renderer.ClearConsole();
                        break;
                    }
                }

                this.renderer.PrintLabirynth(this.grid);

                this.renderer.PrintMessage(GameMassages.InviteUserInputMessage);
                Commands userCommand = this.userInterface.GetCommandFromInput();
                this.ExecuteCommand(userCommand);

                this.isGameOver = this.IsGameOver(this.player.Position.X, this.player.Position.Y, this.grid);
            }
        }

        /// <summary>
        /// Implementation of "Start" command
        /// </summary>
        private void ProcessStartCommand()
        {
            this.renderer.PrintLevels();
            this.player = new Player();
            this.grid = new Grid();
            var command = this.userInterface.GetCommandFromInput();
            this.renderer.ClearConsole();
            this.ExecuteCommand(command);
        }

        /// <summary>
        /// Method that returs to main menu
        /// </summary>
        private void GoBackToInitialMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            this.renderer.PrintMessage(GameMassages.PressBackMessage);

            var pressedKey = Console.ReadKey(true);

            while (pressedKey.Key != ConsoleKey.Backspace)
            {
                pressedKey = Console.ReadKey(true);

                if (pressedKey.Key == ConsoleKey.Backspace)
                {
                    break;
                }
            }

            this.renderer.ClearConsole();
            this.renderer.PrintMenu();
        }

        /// <summary>
        /// Save player score after game ended
        /// </summary>
        private void SaveScore()
        {
            this.renderer.PrintMessage(GameMassages.EnterNameMessage);
            this.player.Name = this.userInterface.GetUserInput();
            this.scoreBoard.AddPlayer(this.player);
        }

        /// <summary>
        /// Test the player movement is valid
        /// </summary>
        /// <param name="position">Player position</param>
        /// <param name="grid">Game field</param>
        /// <returns></returns>
        private bool IsMoveValid(Position position, IGrid grid)
        {
            if (position.X < 0 || position.X > grid.TotalRows - 1 ||
                position.Y < 0 || position.Y > grid.TotalCols - 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Verify that the game is over
        /// </summary>
        /// <param name="playerPositionX">Player position X</param>
        /// <param name="playerPositionY">Player position Y</param>
        /// <param name="grid">Game field</param>
        /// <returns></returns>
        private bool IsGameOver(int playerPositionX, int playerPositionY, IGrid grid)
        {
            if ((playerPositionX > 0 && playerPositionX < grid.TotalRows - 1) &&
                (playerPositionY > 0 && playerPositionY < grid.TotalCols - 1))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Аuxiliary method for save game
        /// </summary>
        /// <returns></returns>
        private Memento SaveMemento()
        {
            char[,] currentField = (char[,])this.grid.Field.Clone();
            Position currentPlayerPosition = (Position)this.player.Position.Clone();
            return new Memento(currentField, currentPlayerPosition);
        }

        /// <summary>
        /// Аuxiliary method for load game
        /// </summary>
        /// <param name="memento">Memento object</param>
        private void RestoreMemento(Memento memento)
        {
            this.grid.Field = (char[,])memento.Field.Clone();
            this.player.Position = memento.Position;
        }
    }
}