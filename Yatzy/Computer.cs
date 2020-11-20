namespace Yatzy
{
    public class Computer : IPlayer
    {
        public int Id { get; private set; }

        public Scorecard Scorecard { get; private set; }
        public Computer(int id, Scorecard scorecard, IOutputWriter writer, IOutputFormatter formatter)
        {

        }

        public DiceController PlayOneTurn()
        {
            throw new System.NotImplementedException();
        }

        public void ScoreOneTurn(DiceController turn)
        {
            throw new System.NotImplementedException();
        }
    }
}