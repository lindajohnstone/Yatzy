namespace Yatzy
{
    public interface ICategory
    {
        int Score(int[] turn);
        public int Id { get;}
    }
}