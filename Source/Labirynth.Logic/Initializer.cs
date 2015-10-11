namespace Labyrinth.Logic
{
    using Labyrinth.Common;
    using Labyrinth.Console.Interfaces;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Models;
    using Labyrinth.Models.Interfaces;

    public class Initializer : IInitializer
    {
        /// <summary>
        /// Initialize game
        /// </summary>
        /// <param name="grid">Field member</param>
        /// <param name="player"Player member></param>
        public void InitializeGame(IGrid grid, IPlayer player)
        {
            this.GenerateGrid(player, grid);
        }

        /// <summary>
        /// Generete game field
        /// </summary>
        /// <param name="grid">Field member</param>
        /// <param name="player"Player member></param>
        /// <returns>Genereted game filed</returns>
        public IGrid GenerateGrid(IPlayer player, IGrid grid)
        {
            DefaultRandomGenerator random = DefaultRandomGenerator.Instance();
            int percentageOfBlockedCells = random.Next(GlobalConstants.MinimumPercentageOfBlockedCells, GlobalConstants.MaximumPercentageOfBlockedCells);

            for (int row = 0; row < grid.TotalRows; row++)
            {
                for (int col = 0; col < grid.TotalCols; col++)
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

            grid.SetCell(grid.TotalRows / 2, grid.TotalCols / 2, GlobalConstants.PlayerSignSymbol);

            this.MakeAtLeastOneExitReachable(grid, player);
            return grid;
        }

        /// <summary>
        /// Маке аt least one possible way out of the maze
        /// </summary>
        /// <param name="generatedGrid">Genereted game field</param>
        /// <param name="player">Player member</param>
        public void MakeAtLeastOneExitReachable(IGrid generatedGrid, IPlayer player)
        {
            DefaultRandomGenerator random = DefaultRandomGenerator.Instance();
            int[] dirX = { 0, 0, 1, -1 };
            int[] dirY = { 1, -1, 0, 0 };
            int numberOfDirections = 4;

            while (this.IsGameOver(player, generatedGrid) == false)
            {
                int randomIndex = random.Next(0, numberOfDirections);

                var nextPosition = new Position(player.Position.X + dirX[randomIndex], player.Position.Y + dirY[randomIndex]);

                if (this.IsInsideGrid(nextPosition, generatedGrid))
                {
                    player.Position = nextPosition;
                    generatedGrid.SetCell(player.Position.X, player.Position.Y, GlobalConstants.FreeCellSymbol);
                }
            }

            player.Position = new Position(generatedGrid.TotalRows / 2, generatedGrid.TotalCols / 2);
            generatedGrid.SetCell(generatedGrid.TotalRows / 2, generatedGrid.TotalCols / 2, GlobalConstants.PlayerSignSymbol);
        }


        /// <summary>
        /// Checks if the player is in game field
        /// </summary>
        /// <param name="position">Player position</param>
        /// <param name="grid">Game field</param>
        /// <returns></returns>
        private bool IsInsideGrid(Position position, IGrid grid)
        {
            if (position.X >= 0 && position.X < grid.TotalRows &&
                    position.Y >= 0 && position.Y < grid.TotalCols)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verify that the game is over
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="grid">The game field</param>
        /// <returns></returns>
        private bool IsGameOver(IPlayer player, IGrid grid)
        {
            if ((player.Position.X > 0 && player.Position.X < grid.TotalRows - 1) &&
                (player.Position.Y > 0 && player.Position.Y < grid.TotalCols - 1))
            {
                return false;
            }

            return true;
        }
    }
}
