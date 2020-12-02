using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    public class OutputFormatter : IOutputFormatter
    {
        public string FormatDiceRoll(int[] dice)
        {
            var builder = new StringBuilder();
            string divider = new string('-', 35);
            builder.AppendLine(divider);
            builder.AppendLine("| Dice Number | 1 | 2 | 3 | 4 | 5 |");
            builder.AppendLine(divider);
            builder.Append("| Dice Value  |");
            foreach (int die in dice)
            {
                builder.Append($" {die} |");
            }
            builder.AppendLine();
            builder.AppendLine(divider);
            return builder.ToString();
        }

        public string FormatScorecard(Scorecard scorecard)
        {
            var builder = new StringBuilder();
            string divider = new string('-', 29);
            builder.AppendLine(divider);
            builder.AppendLine("|    Category     |  Score  |");
            builder.AppendLine(divider);
            foreach (var line in scorecard.Scores)
            {
                var score = Math.Clamp(line.Value, 0, 100);
                builder.AppendLine($"| {line.Key.GetDescription(),-15} | {score,7} |");
            }
            builder.AppendLine(divider);
            builder.AppendLine($"| Total Score:          {scorecard.GetTotalScore(),3} |");
            builder.AppendLine(divider);
            builder.AppendLine();
            return builder.ToString();
        }

        public string FormatCategoryList(List<Category> categories)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Available Categories:");
            foreach (var cat in categories)
            {
                builder.AppendLine($"{(int)cat,2}: {cat.GetDescription(),-15}");
            }
            builder.AppendLine();
            return builder.ToString();
        }
    }
}