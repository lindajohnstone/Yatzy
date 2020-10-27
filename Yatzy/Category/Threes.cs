namespace Yatzy
{
    public class Threes : ICategory
    {
        public int Id => 3;

        public int Score(int[] turn)
        {
            var total = 0;
            foreach (var value in turn)
            {
                if(value == 3) total += value;
            }
            return total;
        }
    }
}