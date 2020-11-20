using System;
using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace tests.Yatzy
{
    public class ScorecardTests
    {
        [Fact]
        public void Should_Add_Score_To_Category()
        {
            // arrange
            var target = new Scorecard();
            var roll = new[] { 1, 2, 3, 4, 5 };
            var expectedScore = 15;
            // act
            target.AddScore(roll, Category.Chance);
            // assert
            Assert.Equal(expectedScore, target.Scores[Category.Chance]);
        }
        [Fact]
        public void Should_Return_Scorecard_Total_Score()
        {
            // arrange
            var target = new Scorecard();
            var roll = new[] { 1, 2, 3, 4, 5 };
            target.AddScore(roll, Category.Chance);
            target.AddScore(roll, Category.SmallStraight);
            var expectedScore = 30;
            // act
            var result = target.GetTotalScore();
            // assert
            Assert.Equal(expectedScore, result);
        }
        [Fact]
        public void Should_Return_Available_Categories_No_Scores()
        {
            // arrange
            var target = new Scorecard();
            List<Category> expected = new List<Category>();
            foreach (Category cat in Enum.GetValues(typeof(Category)))
            {
                expected.Add(cat);
            }
            // act
            var result = target.GetAvailableCategories();

            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Return_Available_Categories_With_Scores()
        {
            // arrange
            var target = new Scorecard();
            var roll = new[] { 1, 2, 3, 4, 5 };
            target.AddScore(roll, Category.Ones);
            target.AddScore(roll, Category.SmallStraight);
            List<Category> expected = new List<Category>();
            foreach (Category cat in Enum.GetValues(typeof(Category)))
            {
                if (cat != Category.Ones && cat != Category.SmallStraight) expected.Add(cat);
            }
            // act
            var result = target.GetAvailableCategories();

            // assert
            Assert.Equal<List<Category>>(expected, result);
        }
    }
}