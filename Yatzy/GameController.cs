using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class GameController
    {
        private IInputReader _reader;
        private IOutputWriter _writer;
        private IOutputFormatter _formatter;
        private List<IPlayer> _players;

        public GameController(IInputReader reader, IOutputWriter writer, IOutputFormatter formatter)
        {
            _reader = reader;
            _writer = writer;
            _formatter = formatter;
            _players = new List<IPlayer>();
        }

        public void RunGame()
        {
            _writer.WriteLine("Welcome to Yatzy!");
            _writer.WriteLine("Would you like to play alone or with another player (human or computer)?");
            _writer.WriteLine("Enter 'Alone', 'Human' or 'Computer'.");
            var playOption = _reader.GetPlayOption();

            _players.Add(new Human(1, new Scorecard(), _reader, _writer, _formatter));
            switch (playOption)
            {
                case PlayOption.Human:
                    _players.Add(new Human(2, new Scorecard(), _reader, _writer, _formatter));
                    break;
                case PlayOption.Computer:
                    _players.Add(new Computer(1, new Scorecard(), _writer, _formatter));
                    break;
            }

            var remainingTurnCount = _players[0].Scorecard.GetAvailableCategories().Count();
            while (remainingTurnCount > 0)
            {
                foreach (var player in _players)
                {
                    var diceController = new DiceController();
                    var turn = player.PlayOneTurn(diceController);
                    player.ScoreOneTurn(turn);
                }
                remainingTurnCount--;
            }

            // TODO: fix scoring for computer
            var results = new Dictionary<string, int>();
            foreach (var player in _players)
            {
                var finalScore = player.GetFinalScore();
                results.Add(finalScore.Key, finalScore.Value);
            }

            if (_players.Count > 1)
            {
                var firstPlayer = results.First();
                var secondPlayer = results.Last();
                var winner = "";
                if (firstPlayer.Value == secondPlayer.Value)
                {
                    winner = $"Both players tie with a score of {firstPlayer.Value}!";
                }
                else if (firstPlayer.Value > secondPlayer.Value)
                {
                    winner = $"{firstPlayer.Key} wins with a score of {firstPlayer.Value}!";
                }
                else
                {
                    winner = $"{secondPlayer.Key} wins with a score of {secondPlayer.Value}!";
                }
                _writer.WriteLine(winner);
            }
        }
    }
}