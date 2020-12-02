using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Yatzy
{
    [ExcludeFromCodeCoverage]
    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine($"{Environment.NewLine}{message}");
        }
    }
}