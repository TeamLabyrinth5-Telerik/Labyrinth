namespace Labyrinth.Models
{
    using System;
    using Labyrinth.Common;
    using Labyrinth.Models.Interfaces;

    public class Player : IPlayer
    {
        private const int InitialPlayerMoveCount = 0;

        private string name;
        private int moveCount;

        public Player()
        {
            this.Name = "Guest";
            this.MoveCount = InitialPlayerMoveCount;
            this.Position = new Position(GlobalConstants.StartPlayerPositionX, GlobalConstants.StartPlayerPositionY);
        }

        public Player(string name)
            : this()
        {
            this.Name = name;
        }

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
                {                               // TODO: Eventually extract message in constant
                    throw new ArgumentException("Move count cannot be negative");
                }

                this.moveCount = value;
            }
        }

        public Position Position { get; set; }
    }
}
