namespace Labyrinth.Models
{
    using System;

    /// <summary>
    /// Class position hold player position
    /// </summary>
    public struct Position : ICloneable
    {
        private int x;
        private int y;

        /// <summary>
        /// Initializes a new instance of the Position
        /// </summary>
        /// <param name="positionX">Coordinate X</param>
        /// <param name="positionY">Coordinate Y</param>
        public Position(int positionX, int positionY)
            : this()
        {
            this.X = positionX;
            this.Y = positionY;
        }

        /// <summary>
        /// Get or set x coordinate
        /// </summary>
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

        /// <summary>
        /// Get or set y coordinate
        /// </summary>
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

        /// <summary>
        /// Clones the current position
        /// </summary>
        /// <returns>Cloned object with same coordinates</returns>
        public object Clone()
        {
            return new Position(this.X, this.Y);
        }
    }
}
