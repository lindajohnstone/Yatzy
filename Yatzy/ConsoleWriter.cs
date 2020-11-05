using System;

namespace Yatzy
{
    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}