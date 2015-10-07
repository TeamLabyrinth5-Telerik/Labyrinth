namespace Labyrinth.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Labyrinth.Models.Interfaces;

    /// <summary>
    /// Class for saving and listing top scorers.
    /// </summary>
    public class Scoreboard
    {
        private IList<IPlayer> players = new List<IPlayer>();

        public IList<IPlayer> Players
        {
            get
            {
                return this.players;
            }
        }

        /// <summary>
        /// Add player to scoreboard
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(IPlayer player)
        {
            this.players.Add(player);
            this.players = this.players.OrderBy(x => x.MoveCount).ToList();
            this.DeleteAllExceptTopPlayers();
        }

        /// <summary>
        /// Get top five players
        /// </summary>
        private void DeleteAllExceptTopPlayers()
        {
            for (int index = 0; index < this.players.Count(); index++)
            {
                if (index > 4)
                {
                    this.players.Remove(this.players[index]);
                }
            }
        }
    }
}