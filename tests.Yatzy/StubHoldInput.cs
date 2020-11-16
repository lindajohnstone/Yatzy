using System;
using System.Collections.Generic;
using Yatzy;

namespace tests.Yatzy
{
    public class StubHoldInput : IInputReader
    {
        Stack<Category> categories;
        public int getDiceToHoldCount = 0;
        public int getPlayerRollChoiceCount;

        public StubHoldInput()
        {
            categories = new Stack<Category>();
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                categories.Push(category);
            }
        }
        public Category GetCategoryChoice(List<Category> availableCategories)
        {
            return categories.Pop();
        }

        public int[] GetDiceToHold()
        {
            getDiceToHoldCount++;
            return new int[2] { 1, 2 };
        }

        public Choice GetPlayerRollChoice()
        {
            getPlayerRollChoiceCount++;
            return Choice.Hold;
        }

        public int GetNumberOfPlayers()
        {
            return 1;
        }
    }
}