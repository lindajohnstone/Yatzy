using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class Pairs : ICategory
    {
        public int Score(int[] turn)
        {
            // logic
            // sort turn descending
            // is turn[0] equal to turn[1]
            // yes - return turn[0] value x 2
            // no - is turn[1] equal to turn[2]
            // yes - return turn[1] x 2
            // no - is turn[2] equal to turn[3]
            // yes - return turn[2] x 2
            // no - is turn[3] equal to turn[4]
            // yes - return turn[3] x 2
            // no - is turn[4] equal to turn[5]
            // yes - return turn[4] x 2
            // no - return 0
            int count = 0;
            var query = turn.OrderByDescending(turn => turn);
            for (int i = 0; i < turn.Length - 1; i++)
            {
                if (turn[i] == turn[i + 1])
                {
                    count = turn[i] + turn[i + 1];
                    return count;
                }
                if (count != 0)
                {
                    break;
                }
            }
            return 0;
        }
    }
}