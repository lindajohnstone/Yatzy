using System.Linq;

namespace Yatzy
{
    public class Chance : ICategory
    {
        public int Id => 15;

        public int Score(int[] turn)
        {
            return turn.Sum();
        }
    }
}