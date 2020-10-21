using System;

namespace Yatzy
{
    public class DiceController
    {
        public DiceController()
        {
        }

        public int[] Roll()
        {
            Random die = new Random();
            var roll = new int[5];
            for (int i = 0; i < 5; i++)
            {
                roll[i] = die.Next(1, 7);
            }
            return roll;
        }

        public int[] Reroll(int[] roll)
        {
            throw new NotImplementedException();
        }
    }
}