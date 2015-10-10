﻿namespace Labyrinth.Models
{
    using System;

    /// <summary>
    /// Class position hold player position
    /// </summary>
    public struct Position : ICloneable
    {
        private int x;
        private int y;

        public Position(int positionX, int positionY)
            : this()
        {
            this.X = positionX;
            this.Y = positionY;
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        public object Clone()
        {
            return new Position(this.X, this.Y);
        }
    }
}
