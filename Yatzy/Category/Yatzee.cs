using System.Linq;

namespace Yatzy
{
    public class Yatzee : ICategory
    {
        public int Id => 14;

        public int Score(int[] turn)
        {
            if (!turn.Distinct().Skip(1).Any())
            {
                return 50;
            }
            return 0;
        }
    }
}