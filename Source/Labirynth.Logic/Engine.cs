namespace Labirynth.Logic
{
    using System;
    using Labirynth.Common;
    using Labirynth.Common.Enums;
    using Labirynth.Logic.Interfaces;
    using Labirynth.Models;
    using Labirynth.Models.Interfaces;

    public class Engine
    {
        private IRenderer renderer;
        private IUserInterface userInterface;
        private IInitializer initializer;
        private IPlayer player;
        private Grid grid;
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
        }

        public void Run()
        {
            this.initializer.InitializeGame(this.grid, this.player);

            while (true)
            {
                if (this.isGameOver)
                {
                    this.renderer.PrintLabirynth(this.grid);
                    this.renderer.PrintMessage(string.Format(GameMassages.WonGameMessage, this.player.MoveCount));
                    this.SaveScore();
                    this.renderer.PrintScore(this.scoreBoard);
                    this.RestartGame();
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
                    {
                        player.MoveCount++;
                        this.Move(0, -1);
                        break;
                    }

                case Commands.R:
                    {
                        player.MoveCount++;
                        this.Move(0, 1);
                        break;
                    }

                case Commands.U:
                    {
                        player.MoveCount++;
                        this.Move(-1, 0);
                        break;
                    }

                case Commands.D:
                    {
                        player.MoveCount++;
                        this.Move(1, 0);
                        break;
                    }

                case Commands.Restart:
                    {
                        this.RestartGame();
                        break;
                    }

                case Commands.Top:
                    {
                        this.renderer.PrintScore(this.scoreBoard);
                        break;
                    }

                case Commands.Exit:
                    {
                        break;
                    }

                case Commands.Invalid:
                    this.renderer.PrintMessage(GameMassages.WrongInputMessage);
                    break;
                default:
                    {
                        this.renderer.PrintMessage(GameMassages.WrongInputAndContinueMessage);
                        this.userInterface.GetUserInput();
                        break;
                    }
            }
        }

        private void RestartGame()
        {
            this.isGameOver = false;
            this.player = new Player();
            this.grid = new Grid();
            this.initializer.InitializeGame(this.grid, this.player);
        }

        private void SaveScore()
        {
            this.renderer.PrintMessage(GameMassages.EnterNameMessage);
            this.player.Name = this.userInterface.GetUserInput();
            this.scoreBoard.AddPlayer(this.player);
        }

        private void Move(int dirX, int dirY)
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
    }
}
