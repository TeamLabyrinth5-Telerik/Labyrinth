namespace Labyrinth.Logic
{
    using Labyrinth.Logic.Interfaces;

    /// <summary>
    /// Implementing bridge design pattern to provides abstract game functionality.
    /// </summary>
    public abstract class Engine : IEngine
    {
        /// <summary>
        /// <see cref="IInitializer"/> readonly field.
        /// </summary>
        protected readonly IInitializer Initializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Engine" /> class.
        /// </summary>
        /// <param name="initializer">Game initializer</param>
        protected Engine(IInitializer initializer)
        {
            this.Initializer = initializer;
        }

        /// <summary>
        /// Game initialization.
        /// </summary>
        public abstract void Run();
    }
}