using System.Linq;

namespace Yatzy
{
    public class Chance
    {

        public Chance()
        {
        }

        public int Score(int[] turn)
        {
            return turn.Sum();
        }
    }
}