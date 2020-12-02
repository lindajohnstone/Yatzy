using System.Collections.Generic;

namespace Yatzy
{
    public interface IOutputFormatter
    {
        string FormatDiceRoll(int[] dice);
        string FormatScorecard(Scorecard scorecard);
        string FormatCategoryList(List<Category> categories);
    }
}