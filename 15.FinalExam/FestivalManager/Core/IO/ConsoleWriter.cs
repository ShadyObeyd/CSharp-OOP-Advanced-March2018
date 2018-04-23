using System;

namespace FestivalManager.Core.IO
{
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void Write(string contents)
        {
            Console.Write(contents);
        }

        public void WriteLine(string contents)
        {
            Console.WriteLine(contents);
        }
    }
}
