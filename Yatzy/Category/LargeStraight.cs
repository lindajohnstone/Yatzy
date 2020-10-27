using System.Linq;

namespace Yatzy
{
    public class LargeStraight : ICategory
    {
        public int Id => 13;

        public int Score(int[] turn)
        {
            var query = turn.OrderBy(turn => turn).ToArray();
            var largeStraight = new [] {2,3,4,5,6};
            if (query.SequenceEqual(largeStraight)) return 20;
            return 0;
        }
    }
}