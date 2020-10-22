using System;

namespace Yatzy
{
    public class DiceController
    {
        private Random _die;
        public DiceController()
        {
            _die = new Random();   
        }

        public int[] Roll()
        {
            var roll = new int[5];
            for (int i = 0; i < 5; i++)
            {
                roll[i] = _die.Next(1, 7);
            }
            return roll;
        }

        public virtual int[] Reroll(int[] roll)
        {
            for (int i = 0; i < 5; i++)
            {
                if(roll[i] == 0) roll[i] = _die.Next(1, 7);
            }
            return roll;
        }
    }
}