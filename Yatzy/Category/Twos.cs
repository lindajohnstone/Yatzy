namespace Yatzy
{
    public class Twos : ICategory
    {
        public int Id => 2;

        public int Score(int[] turn)
        {
            var total = 0;
            foreach (var value in turn)
            {
                if(value == 2) total += value;
            }
            return total;
        }
    }
}