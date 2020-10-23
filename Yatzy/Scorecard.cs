using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class Scorecard
    {
        public Dictionary<Category, int>Scores ;

        public Scorecard()
        {
            foreach(Category cat in Enum.GetValues(typeof(Category)))
            {
                Scores.Add(cat, -1);
            }
        }

        public void AddScore(int[] roll, Category value)
        {
            throw new NotImplementedException();
        }

         
    }
}