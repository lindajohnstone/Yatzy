using System.Linq;

namespace Yatzy
{
    public class SmallStraight : ICategory
    {
        public int Id => 12;

        public int Score(int[] turn)
        {
            var query = turn.OrderBy(turn => turn).ToArray();
            var smallStraight = new [] {1,2,3,4,5};
            if (query.SequenceEqual(smallStraight)) return 15;
            return 0;
        }
    }
}