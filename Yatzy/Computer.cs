using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Yatzy
{
    public class Computer : IPlayer
    {
        private IOutputWriter _writer;
        private IOutputFormatter _formatter;

        public int Id { get; private set; }

        public Scorecard Scorecard { get; private set; }
        public Computer(int id, Scorecard scorecard, IOutputWriter writer, IOutputFormatter formatter)
        {
            _writer = writer;
            _formatter = formatter;
            Id = id;
            Scorecard = scorecard;
        }

        public DiceController PlayOneTurn()
        {
            var turn = new DiceController();
            turn.RollAllDice();
            Choice choice;
            var turnCount = 1;
            while (turnCount < 3)
            {
                _writer.WriteLine("The computers' roll:");
                _writer.WriteLine(_formatter.FormatDiceRoll(turn.Dice));
                choice = DecidePlayerRollChoice(turn);
                Thread.Sleep(3000);
                _writer.WriteLine($"The computer has chosen to {choice}.");
                if (choice == Choice.End) break;
                var heldDice = DecideDiceToHold(turn);
                var diceNumbers = "";
                foreach(var die in heldDice)
                {
                    diceNumbers += $"{die} ";
                }
                _writer.WriteLine($"The computer has decided to hold dice numbers: {diceNumbers}");
                _writer.WriteLine("Rerolling...");
                for (int diceNum = 1; diceNum < 6; diceNum++)
                {
                    if (!heldDice.Contains(diceNum))
                    {
                        turn.RollOneDie(diceNum - 1);
                    }
                }
                turnCount++;
                Thread.Sleep(3000);
            }
            _writer.WriteLine("The computers' final roll:");
            _writer.WriteLine(_formatter.FormatDiceRoll(turn.Dice));
            _writer.WriteLine("The computers' turn is now over.");
            return turn;
        }

        private int[] DecideDiceToHold(DiceController turn)
        {
            var numbersToKeep = new int[] {4,5,6};
            var diceToHold = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                if (numbersToKeep.Contains(turn.Dice[i])) diceToHold.Add(i + 1);
            }
            var random = new Random();
            if (diceToHold.Count == 5) diceToHold.Remove(random.Next(1,6));
            return diceToHold.ToArray();
        }
        
        private Choice DecidePlayerRollChoice(DiceController turn)
        {
            Dictionary<Category, int> possibleScores = GeneratePossibleScores(turn);
            if (possibleScores.Any(_ => _.Value > 15)) return Choice.End;
            return Choice.Hold;
        }

        private Dictionary<Category, int> GeneratePossibleScores(DiceController turn)
        {
            var possibleScores = new Dictionary<Category, int>();
            foreach (var cat in Scorecard.GetAvailableCategories())
            {
                var category = Scorecard.categories.Find(_ => _.Id == (int)cat);
                var score = category.Score(turn.Dice);
                possibleScores.Add(cat, score);
            }
            return possibleScores;
        }

        public void ScoreOneTurn(DiceController turn)
        {
            _writer.WriteLine("The computers' scorecard:");
            _writer.WriteLine(_formatter.FormatScorecard(Scorecard));
            _writer.WriteLine("The computer is choosing a category to score in...");
            Thread.Sleep(2000);
            var availableCategories = Scorecard.GetAvailableCategories();
            _writer.WriteLine(_formatter.FormatCategoryList(availableCategories));
            var category = GetCategoryChoice(turn);
            _writer.WriteLine($"The computer has chosen to score in {category.GetDescription()}");
            Scorecard.AddScore(turn.Dice, category);
            _writer.WriteLine("The computers' scorecard:");
            _writer.WriteLine(_formatter.FormatScorecard(Scorecard));
        }

        private Category GetCategoryChoice(DiceController turn)
        {
            var possibleScores = GeneratePossibleScores(turn);
            var bestScore = possibleScores.First();
            foreach (var possibleScore in possibleScores)
            {
                if(possibleScore.Value > bestScore.Value) bestScore = possibleScore;
            }
            return bestScore.Key;
        }

        public KeyValuePair<string, int> GetFinalScore()
        {
            _writer.WriteLine("The computers' result is:");
            _writer.WriteLine(_formatter.FormatScorecard(Scorecard));
            return new KeyValuePair<string, int> ($"The computer", Scorecard.GetTotalScore());
        }
    }
}