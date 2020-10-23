using System;
using System.Linq;

namespace Yatzy
{
    public class Pairs : ICategory
    {
        public int Id => 7;

        public int Score(int[] turn)
        {
            int count = 0;
            var query = turn.OrderByDescending(turn => turn).ToArray();
            
            for (int i = 0; i < turn.Length - 1; i++)
            {
                int firstIndex = Array.IndexOf(query, query[i]);
                int lastIndex = Array.LastIndexOf(query, query[i]);
                if (firstIndex != lastIndex)
                {
                    count = query[i] + query[i];
                    return count; 
                }
            }
            return 0;
        }
    }
}