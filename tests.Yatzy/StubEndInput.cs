using System;
using System.Collections.Generic;
using Yatzy;

namespace tests.Yatzy
{
    public class StubEndInput : IInputReader
    {
        Stack<Category> categories;
        public int getCategoryChoiceCount = 0;
        public StubEndInput()
        {
            categories = new Stack<Category>();
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                categories.Push(category);
            }
        }
        public Category GetCategoryChoice(List<Category> availableCategories)
        {
            getCategoryChoiceCount++;
            return categories.Pop();
        }

        public int[] GetDiceToHold()
        {
            return new int[5];
        }

        public Choice GetPlayerRollChoice()
        {
            return Choice.End;
        }

        public PlayOption GetPlayOption()
        {
            return PlayOption.Alone;
        }
    }
}