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
            var roll = new [] {1, 2, 3, 4, 5};
            var expectedScore = 15;
            // act
            target.AddScore(roll, Category.Chance);
            // assert
            Assert.Equal(expectedScore, target.Scores[Category.Chance]);
        }
    }
}