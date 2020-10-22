using Yatzy;

namespace tests.Yatzy
{
    public class DiceControllerStub : DiceController
    {
        public override int[] Reroll(int[] roll)
        {
            roll[1] = 2;
            roll[3] = 3;
            return roll;
        }
        
    }
}