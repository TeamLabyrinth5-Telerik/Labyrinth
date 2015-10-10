namespace Labyrinth.Models
{
    using System;
    using Labyrinth.Common;
    using Labyrinth.Models.Interfaces;

    /// <summary>
    /// Main Player class that save its name and count of moves
    /// </summary>
    public class Player : IPlayer
    {
        private const int InitialPlayerMoveCount = 0;

        private string name;
        private int moveCount;

        /// <summary>
        /// Setting player name to 'Guest'
        /// </summary>
        public Player()
        {
            this.Name = "Guest";
            this.MoveCount = InitialPlayerMoveCount;
            this.Position = new Position(GlobalConstants.StartPlayerPositionX, GlobalConstants.StartPlayerPositionY);
        }

        /// <summary>
        /// Setting player name to given string
        /// </summary>
        /// <param name="name">The value to be set</param>
        public Player(string name)
            : this()
        {
            this.Name = name;
        }

        /// <summary>
        /// Setting player name and position
        /// </summary>
        /// <param name="name">The value to be set</param>
        /// <param name="position">The value to be set</param>
        public Player(string name, Position position)
            : this(name)
        {
            this.Position = position;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.name = value;
                }
            }
        }

        public int MoveCount
        {
            get
            {
                return this.moveCount;
            }

            set
            {
                if (value < 0)
                {                               
                    throw new ArgumentException("Move count cannot be negative");
                }

                this.moveCount = value;
            }
        }

        public Position Position { get; set; }
    }
}
