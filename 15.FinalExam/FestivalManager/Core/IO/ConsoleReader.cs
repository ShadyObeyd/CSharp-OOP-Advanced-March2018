using System;

namespace FestivalManager.Core.IO
{
    using Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
