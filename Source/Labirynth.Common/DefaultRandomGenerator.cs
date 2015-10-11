namespace Labyrinth.Common
{
    using System;
    using Labyrinth.Common.Interfaces;

    /// <summary>
    /// Represents default random numbers generator
    /// Implement Singleton Design Pattern.
    /// </summary>
    /// <seealso cref="Labyrinth.Common.Interfaces.IRandomGenerator"/>
    public sealed class DefaultRandomGenerator : IRandomGenerator
    {
        /// <summary>
        /// DefaultRandomGenerato instance
        /// </summary>
        private static DefaultRandomGenerator instance;

        /// <summary>
        /// The random
        /// </summary>
        private readonly Random random = new Random();

        /// <summary>
        /// Get the DefaultRandomGenerator instance using Lazy initialization
        /// </summary>
        /// <returns>
        /// The instance
        /// </returns>
        public static DefaultRandomGenerator Instance()
        {
            if (instance == null)
            {
                instance = new DefaultRandomGenerator();
            }

            return instance;
        }

        /// <summary>
        /// Gets the next random integer
        /// </summary>
        /// <param name="minValue">The minumum value</param>
        /// <param name="maxValue">The maximum value</param>
        /// <returns>
        /// Random integer number
        /// </returns>
        public int Next(int minValue, int maxValue)
        {
            return this.random.Next(minValue, maxValue);
        }
    }
}
