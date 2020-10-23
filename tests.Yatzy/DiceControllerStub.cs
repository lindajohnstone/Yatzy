using Yatzy;

namespace tests.Yatzy
{
    public class DiceControllerStub : DiceController
    {
        new public int[] Dice { get; set; }
        public override void RollAllDice()
        {
            Dice = new int[] {1, 2, 3, 4, 5};
        }

        public override void RollOneDie(int diceNumber)
        {
            Dice[diceNumber] = 6;
        }

        public int[] getDiceArray()
        {
            var result = new int[5];
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = Dice[i];
            }
            return result;
        }
        
    }
}