namespace Labyrinth.Common.Interfaces
{
    /// <summary>
    /// Interface for Random Generator
    /// </summary>
    public interface IRandomGenerator
    {
        /// <summary>
        /// Gets the next random integer
        /// </summary>
        /// <param name="minValue">The minumum value</param>
        /// <param name="maxValue">The maximum value</param>
        /// <returns>
        /// Random integer number
        /// </returns>
        int Next(int minValue, int maxValue);
    }
}
