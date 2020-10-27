namespace Yatzy
{
    public class Fours : ICategory
    {
        public int Id => 4;

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