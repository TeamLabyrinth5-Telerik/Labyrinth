namespace Labyrinth.Logic
{
    using System;
    using Labyrinth.Common;
    using Labyrinth.Common.Enums;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Models;
    using Labyrinth.Models.Interfaces;

    public class Engine
    {
        private IRenderer renderer;
        private IUserInterface userInterface;
        private IInitializer initializer;
        private IPlayer player;
        private Grid grid;
        private GridMemory gridMemory;
        private Scoreboard scoreBoard;
        private bool isGameOver;

        public Engine(IRenderer renderer, IUserInterface userInterface, IInitializer initializer)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.initializer = initializer;
            this.scoreBoard = new Scoreboard();
            this.player = new Player();
            this.grid = new Grid(GlobalConstants.GridRowsCount, GlobalConstants.GridColsCount);
            this.gridMemory = new GridMemory();
        }

        public void Run()
        {
            this.renderer.PrintMessage(GameMassages.WelcomeMessage);
            this.renderer.PrintMessage(GameMassages.HowToPlayMessage);
            this.initializer.InitializeGame(this.grid, this.player);

            while (true)
            {
                if (this.isGameOver)
                {
                    this.renderer.PrintLabirynth(this.grid);
                    this.renderer.PrintMessage(string.Format(GameMassages.WonGameMessage, this.player.MoveCount));
                    this.SaveScore();
                    this.renderer.PrintScore(this.scoreBoard);
                    this.ProcessRestartGameCommand();
                }

                this.renderer.PrintLabirynth(this.grid);

                this.renderer.PrintMessage(GameMassages.InviteUserInputMessage);
                Commands userCommand = this.userInterface.GetCommandFromInput();
                this.ExecuteCommand(userCommand, this.player);

                this.isGameOver = this.IsGameOver(this.player.Position.X, this.player.Position.Y);
            }
        }

        private void ExecuteCommand(Commands command, IPlayer player)
        {
            switch (command)
            {
                case Commands.L:
                    player.MoveCount++;
                    this.renderer.ClearConsole();
                    this.ProcessMoveCommand(0, -1);
                    break;
                case Commands.R:
                    player.MoveCount++;
                    this.renderer.ClearConsole();
                    this.ProcessMoveCommand(0, 1);
                    break;
                case Commands.U:
                    player.MoveCount++;
                    this.renderer.ClearConsole();
                    this.ProcessMoveCommand(-1, 0);
                    break;
                case Commands.D:
                    player.MoveCount++;
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
                case Commands.Restart:
                    this.ProcessRestartGameCommand();
                    break;
                case Commands.Top:
                    this.ProcessPrintScoreCommand();
                    break;
                case Commands.Exit:
                    this.ProcessExitCommand();
                    break;
                case Commands.Invalid:
                    this.ProcessInvalidCommand();
                    break;
                default:
                    this.renderer.PrintMessage(GameMassages.WrongInputAndContinueMessage);
                    this.userInterface.GetUserInput();
                    break;
            }
        }

        private void ProcessSaveCommand()
        {
            this.gridMemory.Memento = this.SaveMemento();
            this.renderer.PrintMessage(GameMassages.GameSaved);
        }

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

        private void ProcessRestartGameCommand()
        {
            this.isGameOver = false;
            this.player = new Player();
            this.grid = new Grid();
            this.initializer.InitializeGame(this.grid, this.player);
        }

        private void ProcessPrintScoreCommand()
        {
            this.renderer.PrintScore(this.scoreBoard);
        }

        private void ProcessInvalidCommand()
        {
            this.renderer.PrintMessage(GameMassages.WrongInputMessage);
        }

        private void ProcessMoveCommand(int dirX, int dirY)
        {
            if (this.IsMoveValid(new Position(this.player.Position.X + dirX, this.player.Position.Y + dirY)) == false)
            {
                return;
            }

            if (this.grid.GetCell(this.player.Position.X + dirX, this.player.Position.Y + dirY) == GlobalConstants.BlockedCellSymbol)
            {
                this.renderer.PrintMessage(GameMassages.WrongInputAndContinueMessage);
                this.userInterface.GetUserInput();
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

        private void ProcessExitCommand()
        {
            this.userInterface.ExitGame();
        }

        private void SaveScore()
        {
            this.renderer.PrintMessage(GameMassages.EnterNameMessage);
            this.player.Name = this.userInterface.GetUserInput();
            this.scoreBoard.AddPlayer(this.player);
        }

        private bool IsMoveValid(Position position)
        {
            if (position.X < 0 || position.X > GlobalConstants.GridRowsCount - 1 ||
                position.Y < 0 || position.Y > GlobalConstants.GridColsCount - 1)
            {
                return false;
            }

            return true;
        }

        private bool IsGameOver(int playerPositionX, int playerPositionY)
        {
            if ((playerPositionX > 0 && playerPositionX < GlobalConstants.GridRowsCount - 1) &&
                (playerPositionY > 0 && playerPositionY < GlobalConstants.GridColsCount - 1))
            {
                return false;
            }

            return true;
        }

        public Memento SaveMemento()
        {
            char[,] currentField = (char[,])this.grid.Field.Clone();
            Position currentPlayerPosition = (Position)this.player.Position.Clone();
            return new Memento(currentField, currentPlayerPosition);
        }

        public void RestoreMemento(Memento memento)
        {
            this.grid.Field = (char[,])memento.Field.Clone();
            this.player.Position = memento.Position;
        }
    }
}