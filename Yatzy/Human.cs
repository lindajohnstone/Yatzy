using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class Human : IPlayer
    {
        public int Id { get; private set; }

        public Scorecard Scorecard { get; private set; }

        private IInputReader _reader;
        private IOutputWriter _writer;
        private IOutputFormatter _formatter;

        public Human(int id, Scorecard scorecard, IInputReader reader, IOutputWriter writer, IOutputFormatter formatter)
        {
            Id = id;
            Scorecard = scorecard;
            _reader = reader;
            _writer = writer;
            _formatter = formatter;
        }

        public DiceController PlayOneTurn()
        {
            _writer.WriteLine($"It's player {Id}'s turn!");
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

        public void ScoreOneTurn(DiceController turn)
        {
            _writer.WriteLine("Your scorecard:");
            _writer.WriteLine(_formatter.FormatScorecard(Scorecard));

            _writer.WriteLine("Please choose a category to score in.");
            var availableCategories = Scorecard.GetAvailableCategories();
            _writer.WriteLine(_formatter.FormatCategoryList(availableCategories));
            var category = _reader.GetCategoryChoice(availableCategories);
            Scorecard.AddScore(turn.Dice, category);
            _writer.WriteLine("Your scorecard:");
            _writer.WriteLine(_formatter.FormatScorecard(Scorecard));
        }

        public KeyValuePair<string, int> GetFinalScore()
        {
            _writer.WriteLine($"Player {Id}, your result is:");
            _writer.WriteLine(_formatter.FormatScorecard(Scorecard));
            return new KeyValuePair<string, int> ($"Player {Id}", Scorecard.GetTotalScore());
        }
    }
}