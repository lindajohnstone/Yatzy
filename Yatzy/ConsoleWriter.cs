using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine($"{Environment.NewLine}{message}");
        }
    }
}