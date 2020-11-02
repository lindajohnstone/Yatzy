using System;

namespace Yatzy
{
    public class ConsoleReader : IInputReader
    {
        public Category GetCategoryChoice()
        {
            var userInput = Console.ReadLine();
            Category result;
            if (Enum.TryParse(typeof(Category), userInput, out var choice))
            {
                result = (Category)choice;
            }
            else 
            {
                Console.WriteLine("Invalid response. Please try again. ");
                result = GetCategoryChoice();
            }
            return result;
        }

        public int[] GetDiceToHold()
        {
            var userInput = Console.ReadLine();
            var diceNumbers = userInput.Split(new char[] {',', ' '});
            if (diceNumbers.Length < 1 || diceNumbers.Length > 5)
            {
                Console.WriteLine("Invalid response. Please hold at least one die and no more than five die. ");

            }
            //int.TryParse(userInput[0], out )
            return new int[5];
        }

        public Choice GetPlayerRollChoice()
        {
            throw new System.NotImplementedException();
        }
    }
}