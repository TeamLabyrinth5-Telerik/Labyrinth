namespace Labirynth.Models
{
    public struct Position
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
    }
}
