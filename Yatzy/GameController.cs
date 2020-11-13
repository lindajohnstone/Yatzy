using System;
using System.Linq;

namespace Yatzy
{
    public class GameController
    {
        private IInputReader _reader;
        private IOutputWriter _writer;
        private IOutputFormatter _formatter;
        private Scorecard _player;

        public GameController(IInputReader reader, IOutputWriter writer, IOutputFormatter formatter)
        {
            _reader = reader;
            _writer = writer;
            _formatter = formatter;
            _player = new Scorecard();
        }

        public void RunGame()
        {
            _writer.WriteLine("Welcome to Yatzy!");
            var remainingTurnCount = _player.GetAvailableCategories().Count();
            while(remainingTurnCount > 0)
            {
                DiceController turn = RunOneTurn();
                ScoreOneTurn(turn);
                remainingTurnCount--;
            }
            _writer.WriteLine("Your result is:");
            _writer.WriteLine(_formatter.FormatScorecard(_player));
        }

        private void ScoreOneTurn(DiceController turn)
        {
            _writer.WriteLine("Your Scorecard:");
            _writer.WriteLine(_formatter.FormatScorecard(_player));

            _writer.WriteLine("Please choose a category to score in.");
            var availableCategories = _player.GetAvailableCategories();
            _writer.WriteLine(_formatter.FormatCategoryList(availableCategories));
            var category = _reader.GetCategoryChoice(availableCategories);
            _player.AddScore(turn.Dice, category);
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