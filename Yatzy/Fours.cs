namespace Yatzy
{
    public class Fours : ICategory
    {
        public int Score(int[] turn)
        {
            var total = 0;
            foreach (var value in turn)
            {
                if(value == 4) total += value;
            }
            return total;
        }
    }
}