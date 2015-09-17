namespace Labirynth.Logic
{
    using System;
    using Labirynth.Common;
    using Labirynth.Logic.Interfaces;
    using Labirynth.Models;
    using Labirynth.Models.Interfaces;

    public class Initializer : IInitializer
    {
        public void InitializeGame(Grid grid, IPlayer player)
        {
            this.GenerateGrid(player, grid);
        }

        private Grid GenerateGrid(IPlayer player, Grid grid)
        {            
            Random rand = new Random();
            int percentageOfBlockedCells = rand.Next(GlobalConstants.MinimumPercentageOfBlockedCells, GlobalConstants.MaximumPercentageOfBlockedCells);

            for (int row = 0; row < GlobalConstants.GridRowsCount; row++)
            {
                for (int col = 0; col < GlobalConstants.GridColsCount; col++)
                {
                    int num = rand.Next(0, 100);
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
            // TODO: Use PrintMessage method
            Console.WriteLine("Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top");
            Console.WriteLine("scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            return grid;
        }
        
        // TODO: Refactor and fix method
        private void MakeAtLeastOneExitReachable(Grid generatedGrid, IPlayer player)
        {
            Random rand = new Random();
            int pathX = player.Position.X; // GlobalConstants.StartPlayerPositionX;
            int pathY = player.Position.Y; // GlobalConstants.StartPlayerPositionY;
            int[] dirX = { 0, 0, 1, -1 };
            int[] dirY = { 1, -1, 0, 0 };
            int numberOfDirections = 4;
            int maximumTimesToChangeAfter = 2;

            while (this.IsGameOver(player) == false)
            {
                int num = rand.Next(0, numberOfDirections);
                int times = rand.Next(0, maximumTimesToChangeAfter);

                if (pathX + dirX[num] >= 0 &&
                    pathX + dirX[num] < GlobalConstants.GridRowsCount &&
                    pathY + dirY[num] >= 0 &&
                    pathY + dirY[num] < GlobalConstants.GridColsCount)
                {
                    pathX += dirX[num];
                    pathY += dirY[num];
                    var currentCell = generatedGrid.GetCell(pathY, pathX);
                    if (currentCell == GlobalConstants.PlayerSignSymbol)
                    {
                        continue;
                    }

                    generatedGrid.SetCell(pathY, pathX, GlobalConstants.FreeCellSymbol);
                }
            }
        }

        private bool IsGameOver(IPlayer player)
        {
            if ((player.Position.X > 0 && player.Position.Y < GlobalConstants.StartPlayerPositionX - 1) &&
                (player.Position.X > 0 && player.Position.Y < GlobalConstants.StartPlayerPositionY - 1))
            {
                return false;
            }

            return true;
        }
    }
}
