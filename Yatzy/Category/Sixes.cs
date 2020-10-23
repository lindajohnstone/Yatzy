namespace Yatzy
{
    public class Sixes : ICategory
    {
        public int Id => 6;

        public int Score(int[] turn)
        {
            var total = 0;
            foreach (var value in turn)
            {
                if(value == 6) total += value;
            }
            return total;
        }
    }
}