using System;
using System.Collections.Generic;

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
            var results = new List<int>();
            foreach (var numberString in diceNumbers)
            {
                if (int.TryParse(numberString, out var number))
                {
                    results.Add(number);
                }
                else
                {
                    GetDiceToHold();
                    break;
                }
            }
            return results.ToArray();
        }

        public Choice GetPlayerRollChoice()
        {
            var userInput = Console.ReadLine();
            Choice result;
            if (Enum.TryParse(typeof(Choice), userInput, out var choice))
            {
                result = (Choice)choice;
            }
            else 
            {
                Console.WriteLine("Invalid response. Please try again. ");
                result = GetPlayerRollChoice();
            }
            return result;
        }
    }
}