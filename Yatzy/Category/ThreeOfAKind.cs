using System.Linq;

namespace Yatzy
{
    public class ThreeOfAKind : ICategory
    {
        public int Id => 9;

        public int Score(int[] turn)
        {
            var query = turn.OrderByDescending(turn => turn).ToArray();
            
            for (int i = 0; i <= turn.Length - 3; i++)
            {
                // start at i, move three
                if (query[i] == query[i+1] && query[i] == query[i+2])
                {
                    return query[i] * 3;
                }
            }
            return 0;
        }
    }
}