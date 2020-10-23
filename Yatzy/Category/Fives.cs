namespace Yatzy
{
    public class Fives : ICategory
    {
        public int Id => 5;

        public int Score(int[] turn)
        {
            var total = 0;
            foreach (var value in turn)
            {
                if(value == 5) total += value;
            }
            return total;
        }
    }
}