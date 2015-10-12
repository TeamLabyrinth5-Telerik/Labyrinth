namespace Labyrinth.Tests.Console
{
    using System.IO;

    public class HelperReader : TextReader
    {
        public HelperReader()
        {
        }

        public override string ReadLine()
        {
            return string.Empty;
        }
    }
}
