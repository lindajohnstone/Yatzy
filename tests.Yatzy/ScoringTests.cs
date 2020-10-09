using System.Collections;
using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace tests.Yatzy
{
    public class ScoringTests
    {
        [Theory]
        [InlineData(new [] {1,1,3,3,6}, 14)]
        [InlineData(new [] {4,5,5,6,1}, 21)]
        public void ShouldTestChanceCategoryRule(int[] turn, int expected)
        {
            // arrange
            var chance = new Chance();
            // act
            var result = chance.Score(turn);
            // assert
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(new [] {1,1,1,1,1}, 50)]
        [InlineData(new [] {1,1,1,2,1}, 0)]
        public void ShouldTestYatzyCategoryRule(int[] turn, int expected)
        {
            //arrange
            var yatzy = new Yatzee();
            //act
            var result = yatzy.Score(turn);
            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new [] {3,3,3,4,4}, 8)]
        [InlineData(new [] {1,1,6,2,6}, 12)]
        [InlineData(new [] {3,3,3,4,1}, 6)]
        [InlineData(new [] {3,3,3,3,1}, 6)]
        [InlineData(new [] {1,2,3,6,6}, 12)]
        [InlineData(new [] {1,2,3,4,5}, 0)]
        public void ShouldTestPairsCategoryRule(int[] turn, int expected)
        {
            // arrange
            var pairs = new Pairs();
            // act
            var result = pairs.Score(turn);
            // assert
            Assert.Equal(expected, result);
        }
    }
}
