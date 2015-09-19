namespace Labyrinth.Models.Interfaces
{
    using System;

    public interface IPlayer
    {
        string Name { get; set; }

        int MoveCount { get; set; }
        
        Position Position { get; set; }
    }
}
