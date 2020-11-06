using System;

namespace Yatzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameController = new GameController(new ConsoleReader(), new ConsoleWriter(), new OutputFormatter());
            gameController.RunGame();
        }
    }
}
