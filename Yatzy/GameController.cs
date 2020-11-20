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
                    _writer.WriteLine($"It's player {player.Id}'s turn!");
                    var turn = player.PlayOneTurn();
                    player.ScoreOneTurn(turn);
                }
                remainingTurnCount--;
            }

            var results = new Dictionary<int, int>();
            foreach (var player in _players)
            {
                _writer.WriteLine($"Player {player.Id}, your result is:");
                _writer.WriteLine(_formatter.FormatScorecard(player.Scorecard));
                results.Add(player.Id, player.Scorecard.GetTotalScore());
            }

            if (_players.Count > 1)
            {
                var firstPlayerScore = results[1];
                var secondPlayerScore = results[2];
                var winner = "";
                if (firstPlayerScore == secondPlayerScore)
                {
                    winner = $"Player 1 and 2 both tie with a score of {firstPlayerScore}!";
                }
                else if (firstPlayerScore > secondPlayerScore)
                {
                    winner = $"Player 1 wins with a score of {firstPlayerScore}!";
                }
                else
                {
                    winner = $"Player 2 wins with a score of {secondPlayerScore}!";
                }
                _writer.WriteLine(winner);
            }
        }
    }
}