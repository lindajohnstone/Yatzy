using System.Collections.Generic;

namespace Yatzy
{
    public interface IInputReader
    {
        Choice GetPlayerRollChoice();
        int[] GetDiceToHold();
        Category GetCategoryChoice(List<Category> availableCategories);
    }
}