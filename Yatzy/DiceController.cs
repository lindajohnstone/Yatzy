using System;
using System.Text;

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

        public virtual void RollOneDie(int diceIndex)
        {
            Dice[diceIndex] = _die.Next(1, 7);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            string divider = new string('-', 35);
            builder.AppendLine(divider);
            builder.AppendLine("| Dice Number | 1 | 2 | 3 | 4 | 5 |");
            builder.AppendLine(divider);
            builder.Append("| Dice Value  |");
            foreach (int die in Dice)
            {
                builder.Append($" {die} |");
            }
            builder.AppendLine();
            builder.AppendLine(divider);
            return builder.ToString();
        }
    }
}