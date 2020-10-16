using System;
using System.Linq;

namespace Yatzy
{
    public class TwoPairs : ICategory
    {
        public int Score(int[] turn)
        {
            int count = 0;
            var pairCount = 0;
            var query = turn.OrderByDescending(turn => turn).ToArray();
            
            for (int i = 0; i <= turn.Length - 2; i++)
            {
                if (query[i] == query[i+1])
                {
                    count += query[i] + query[i+1];
                    pairCount++;
                    i++;
                }
            }
            if (pairCount != 2)
            {
                count = 0;
            }
            return count; 
        }
    }
}