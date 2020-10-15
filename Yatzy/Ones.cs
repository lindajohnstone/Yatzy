namespace Yatzy
{
    public class Ones : ICategory
    {
        public int Score(int[] turn)
        {
            var total = 0;
            foreach (var value in turn)
            {
                if(value == 1) total += value;
            }
            return total;
        }
    }
}