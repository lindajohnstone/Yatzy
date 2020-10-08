using System.Collections;
using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace tests.Yatzy
{
    public class ScoringTests
    {
        [Theory]
        [InlineData(1,1,3,3,6, 14)]
        [InlineData(4,5,5,6,1, 21)]
        //[ClassData(typeof(ChanceTestData))]
        public void ShouldTestChanceCategoryRule(int one, int two, int three, int four, int five, int expected)
        {
            // arrange
            var chance = new Chance();
            var turn = new [] {one, two, three, four, five};
            // act
            var result = chance.Score(turn);
            // assert
            Assert.Equal(expected, result);
        }
    }
}
