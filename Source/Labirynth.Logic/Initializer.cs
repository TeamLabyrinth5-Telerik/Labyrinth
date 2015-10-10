namespace Labyrinth.Logic
{
    using Labyrinth.Common;
    using Labyrinth.Console;
    using Labyrinth.Console.Interfaces;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Models;
    using Labyrinth.Models.Interfaces;

    public class Initializer : IInitializer
    {
        public void InitializeGame(IGrid grid, IPlayer player)
        {
            this.GenerateGrid(player, grid);
        }

        private IGrid GenerateGrid(IPlayer player, IGrid grid)
        {
            DefaultRandomGenerator random = DefaultRandomGenerator.Instance();
            int percentageOfBlockedCells = random.Next(GlobalConstants.MinimumPercentageOfBlockedCells, GlobalConstants.MaximumPercentageOfBlockedCells);

            for (int row = 0; row < GlobalConstants.GridRowsCount; row++)
            {
                for (int col = 0; col < GlobalConstants.GridColsCount; col++)
                {
                    int num = random.Next(0, 100);
                    if (num < percentageOfBlockedCells)
                    {
                        grid.SetCell(row, col, GlobalConstants.BlockedCellSymbol);
                    }
                    else
                    {
                        grid.SetCell(row, col, GlobalConstants.FreeCellSymbol);
                    }
                }
            }

            grid.SetCell(GlobalConstants.StartPlayerPositionX, GlobalConstants.StartPlayerPositionY, GlobalConstants.PlayerSignSymbol);

            this.MakeAtLeastOneExitReachable(grid, player);
            return grid;
        }

        private void MakeAtLeastOneExitReachable(IGrid generatedGrid, IPlayer player)
        {
            DefaultRandomGenerator random = DefaultRandomGenerator.Instance();
            int[] dirX = { 0, 0, 1, -1 };
            int[] dirY = { 1, -1, 0, 0 };
            int numberOfDirections = 4;

            while (this.IsGameOver(player) == false)
            {
                int randomIndex = random.Next(0, numberOfDirections);

                var nextPosition = new Position(player.Position.X + dirX[randomIndex], player.Position.Y + dirY[randomIndex]);

                if (this.IsInsideGrid(nextPosition, generatedGrid))
                {
                    player.Position = nextPosition;
                    generatedGrid.SetCell(player.Position.X, player.Position.Y, GlobalConstants.FreeCellSymbol);
                }
            }

            player.Position = new Position(GlobalConstants.StartPlayerPositionX, GlobalConstants.StartPlayerPositionY);
            generatedGrid.SetCell(GlobalConstants.StartPlayerPositionX, GlobalConstants.StartPlayerPositionY, GlobalConstants.PlayerSignSymbol);
        }

        private bool IsInsideGrid(Position position, IGrid grid)
        {
            if (position.X >= 0 && position.X < GlobalConstants.GridRowsCount &&
                    position.Y >= 0 && position.Y < GlobalConstants.GridColsCount)
            {
                return true;
            }

            return false;
        }

        private bool IsGameOver(IPlayer player)
        {
            if ((player.Position.X > 0 && player.Position.X < GlobalConstants.GridRowsCount - 1) &&
                (player.Position.Y > 0 && player.Position.Y < GlobalConstants.GridColsCount - 1))
            {
                return false;
            }

            return true;
        }
    }
}
