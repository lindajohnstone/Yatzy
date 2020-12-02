using System.Collections.Generic;
using Yatzy;

namespace tests.Yatzy
{
    internal class DiceControllerComputerStub : DiceController
    {
        //new public int[] Dice { get; set; }
        private int _rollIndex;
        public List<int[]> PotentialDiceRolls { get; set; }
        public DiceControllerComputerStub(int index)
        {
            _rollIndex = index;
            PotentialDiceRolls = new List<int[]> 
            {
                new int[] { 5, 5, 5, 5, 5},
                new int[] {1, 2, 3, 1, 4}
            };
        }
        public override void RollAllDice()
        {
            Dice = PotentialDiceRolls[_rollIndex];
        }

        public override void RollOneDie(int diceNumber)
        {
            Dice[diceNumber] = -1;
        }
    }
}