using System;
using System.Collections.Generic;
using Yatzy;

namespace tests.Yatzy
{
    public class TwoPlayerStub : IInputReader
    {
        internal int getCategoryChoiceCount;
        internal int getPlayerRollChoiceCount;
        Stack<Category> categories;

        public TwoPlayerStub()
        {
            categories = new Stack<Category>();
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                categories.Push(category);
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
            getPlayerRollChoiceCount++;
            return Choice.End;
        }

        public PlayOption GetPlayOption()
        {
            return PlayOption.Human;
        }
    }
}