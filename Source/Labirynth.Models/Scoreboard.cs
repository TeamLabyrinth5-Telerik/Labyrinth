namespace Labyrinth.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Labyrinth.Models.Interfaces;

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

        public void AddPlayer(IPlayer player)
        {
            this.players.Add(player);
            this.players = this.players.OrderBy(x => x.MoveCount).ToList();
            this.DeleteAllExceptTopPlayers();
        }

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