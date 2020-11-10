using System.Diagnostics.CodeAnalysis;
using System;

namespace Yatzy
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            var gameController = new GameController(new ConsoleReader(), new ConsoleWriter(), new OutputFormatter());
            gameController.RunGame();
        }
    }
}
