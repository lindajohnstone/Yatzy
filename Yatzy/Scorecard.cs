using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class Scorecard
    {
        public Dictionary<Category, int>Scores ;
        List<ICategory> categories;

        public Scorecard()
        {
            Scores = new Dictionary<Category, int>();
            foreach(Category cat in Enum.GetValues(typeof(Category)))
            {
                Scores.Add(cat, -1);
            }
            categories = new List<ICategory> { new Ones(), new Twos(), new Threes(), new Fours(), new Fives(), 
                new Sixes(), new Pairs(), new TwoPairs(), new ThreeOfAKind(), new FourOfAKind(), new FullHouse(),
                new SmallStraight(), new LargeStraight(), new Yatzee(), new Chance() };
        }

        public void AddScore(int[] roll, Category value)
        {
            var category = categories.Find(_ => _.Id == (int)value);
            var score = category.Score(roll);
            Scores.Remove(value);
            Scores.Add(value, score);
        }

        public int GetTotalScore()
        {
            var total = Scores.Values.Where(_ => _ > -1);
            return total.Sum();
        }

        public List<Category> GetAvailableCategories()
        {
            var categories = Scores.Where(_ => _.Value == -1);
            return categories.Select(_ => _.Key).ToList();
        }
    }
}