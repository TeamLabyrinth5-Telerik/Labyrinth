using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
