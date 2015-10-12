using System;
using System.Linq;
namespace Labyrinth.Tests.Console
{
    using System;
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
