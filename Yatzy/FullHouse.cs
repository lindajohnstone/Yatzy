using System.Linq;

namespace Yatzy
{
    public class FullHouse : ICategory
    {
        public int Score(int[] turn)
        {
            var pair = new Pairs();
            var threeOfAKind = new ThreeOfAKind();
            
            if (!turn.Distinct().Skip(1).Any()) return 0;   
            if(pair.Score(turn) > 0 && threeOfAKind.Score(turn) > 0) return turn.Sum();
            return 0;
        }
    }
}