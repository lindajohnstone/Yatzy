using System.Linq;

namespace Yatzy
{
    public class FourOfAKind : ICategory
    {
        public int Id => 10;

        public int Score(int[] turn)
        {
            var numberGroups = turn.GroupBy(_ => _);
            foreach(var group in numberGroups)
            {
                if(group.Count() >= 4) return group.Key * 4;
            }
            return 0;
        }
    }
}