using System.Linq;

namespace Yatzy
{
    public class Chance : ICategory
    {
        public int Score(int[] turn)
        {
            return turn.Sum();
        }
    }
}