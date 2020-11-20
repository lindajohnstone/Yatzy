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
        private List<Scorecard> _players;

        public GameController(IInputReader reader, IOutputWriter writer, IOutputFormatter formatter)
        {
            _reader = reader;
            _writer = writer;
            _formatter = formatter;
            _players = new List<Scorecard>();
        }

        public void RunGame()
        {
            _writer.WriteLine("Welcome to Yatzy!");
            _writer.WriteLine("Please enter the number of players (1 or 2):");
            var playerCount = _reader.GetNumberOfPlayers();
            for (int playerNo = 1; playerNo <= playerCount; playerNo++)
            {
                _players.Add(new Scorecard(playerNo));
            }

            var remainingTurnCount = _players[0].GetAvailableCategories().Count();
            while (remainingTurnCount > 0)
            {
                foreach (var player in _players)
                {
                    _writer.WriteLine($"It's player {player.Id}'s turn!");
                    DiceController turn = RunOneTurn();
                    ScoreOneTurn(turn, player);
                }
                remainingTurnCount--;
            }

            var results = new Dictionary<int, int>();
            foreach (var player in _players)
            {
                _writer.WriteLine($"Player {player.Id}, your result is:");
                _writer.WriteLine(_formatter.FormatScorecard(player));
                results.Add(player.Id, player.GetTotalScore());
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

        private void ScoreOneTurn(DiceController turn, Scorecard player)
        {
            _writer.WriteLine("Your Scorecard:");
            _writer.WriteLine(_formatter.FormatScorecard(player));

            _writer.WriteLine("Please choose a category to score in.");
            var availableCategories = player.GetAvailableCategories();
            _writer.WriteLine(_formatter.FormatCategoryList(availableCategories));
            var category = _reader.GetCategoryChoice(availableCategories);
            player.AddScore(turn.Dice, category);
        }

        private DiceController RunOneTurn()
        {
            var turn = new DiceController();
            turn.RollAllDice();
            Choice choice;
            var turnCount = 1;
            while (turnCount < 3)
            {
                _writer.WriteLine("Your roll:");
                _writer.WriteLine(_formatter.FormatDiceRoll(turn.Dice));
                _writer.WriteLine("Type 'Hold' to select dice to hold or 'End' to end your turn.");
                choice = _reader.GetPlayerRollChoice();
                if (choice == Choice.End) break;
                _writer.WriteLine("Please enter the numbers of the dice you which to hold separated by either a comma (,) or a space.");
                var heldDice = _reader.GetDiceToHold();
                for (int diceNum = 1; diceNum < 6; diceNum++)
                {
                    if (!heldDice.Contains(diceNum))
                    {
                        turn.RollOneDie(diceNum - 1);
                    }
                }
                turnCount++;
            }
            _writer.WriteLine("Your final roll:");
            _writer.WriteLine(_formatter.FormatDiceRoll(turn.Dice));
            _writer.WriteLine("Your turn is now over.");
            return turn;
        }
    }
}