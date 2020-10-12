namespace Yatzy
{
    public class Numbers
    {
        public int Score(int[] turn, int number)
        {
            var total = 0;
            foreach (var value in turn)
            {
                if(value == number) total += value;
            }
            return total;
        }
    }
}