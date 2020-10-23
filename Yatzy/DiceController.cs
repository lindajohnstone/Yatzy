using System;

namespace Yatzy
{
    public class DiceController
    {
        private Random _die;
        public int[] Dice { get; private set; }

        public DiceController()
        {
            _die = new Random();
            Dice = new int[5];   
        }

        public virtual void RollAllDice()
        {
            for (int i = 0; i < 5; i++)
            {
                Dice[i] = _die.Next(1, 7);
            }
        }

        public virtual void RollOneDie(int diceNumber)
        {
            Dice[diceNumber] = _die.Next(1, 7);
        }
    }
}