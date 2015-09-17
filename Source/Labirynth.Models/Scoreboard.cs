﻿namespace Labirynth.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Labirynth.Models.Interfaces;

    public class Scoreboard
    {
        private List<IPlayer> players = new List<IPlayer>();

        public List<IPlayer> Players
        {
            get
            {
                return this.players;
            }
        }

        public void AddPlayer(IPlayer player)
        {
            this.players.Add(player);
            this.players.OrderByDescending(x => x.MoveCount);
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