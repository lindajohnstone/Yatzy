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
        [InlineData(new [] {1,2,1,3,4}, 2)]
        public void ShouldTestPairsCategoryRule(int[] turn, int expected)
        {
            // arrange
            var pairs = new Pairs();
            // act
            var result = pairs.Score(turn);
            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new [] {1,1,2,4,4}, 2)]
        [InlineData(new [] {2,3,2,5,1}, 1)]
        [InlineData(new [] {3,3,3,4,5}, 0)]
        public void ShouldTestOnesRule(int[] turn, int expectedResult)
        {
            // arrange
            var numbers = new Ones();
            // act
            var result = numbers.Score(turn);
            // assert
            Assert.Equal(expectedResult, result);
        }
[Theory]
        [InlineData(new [] {1,1,2,4,4}, 2)]
        [InlineData(new [] {2,3,2,5,1}, 4)]
        [InlineData(new [] {3,3,3,4,5}, 0)]
        public void ShouldTestTwosRule(int[] turn, int expectedResult)
        {
            // arrange
            var numbers = new Twos();
            // act
            var result = numbers.Score(turn);
            // assert
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData(new [] {1,1,2,4,4}, 0)]
        [InlineData(new [] {2,3,2,5,1}, 3)]
        [InlineData(new [] {3,3,3,4,5}, 9)]
        public void ShouldTestThreesRule(int[] turn, int expectedResult)
        {
            // arrange
            var numbers = new Threes();
            // act
            var result = numbers.Score(turn);
            // assert
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData(new [] {1,1,2,4,4}, 8)]
        [InlineData(new [] {2,3,2,5,1}, 0)]
        [InlineData(new [] {3,3,3,4,5}, 4)]
        public void ShouldTestFoursRule(int[] turn, int expectedResult)
        {
            // arrange
            var numbers = new Fours();
            // act
            var result = numbers.Score(turn);
            // assert
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData(new [] {1,1,2,4,4}, 0)]
        [InlineData(new [] {2,3,2,5,1}, 5)]
        [InlineData(new [] {3,3,5,4,5}, 10)]
        public void ShouldTestFivesRule(int[] turn, int expectedResult)
        {
            // arrange
            var numbers = new Fives();
            // act
            var result = numbers.Score(turn);
            // assert
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData(new [] {1,1,2,4,4}, 0)]
        [InlineData(new [] {1,2,6,5,6}, 12)] 
        [InlineData(new [] {1,6,6,5,6}, 18)]       
        public void ShouldTestSixesRule(int[] turn, int expectedResult)
        {
            // arrange
            var numbers = new Sixes();
            // act
            var result = numbers.Score(turn);
            // assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new [] {1,1,2,3,3}, 8)]
        [InlineData(new [] {1,1,2,3,4}, 0)]
        [InlineData(new [] {2,2,2,2,5}, 8)]
        [InlineData(new [] {1,1,2,2,2}, 6)]
       
        public void ShouldTestTwoPairsRule(int[] turn, int expectedResult)
        {
            // arrange
            var target = new TwoPairs();

            // act
            var result = target.Score(turn);

            // assert
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData(new [] {3,3,3,4,5},9)]
        [InlineData(new [] {1,2,3,3,3},9)]
        [InlineData(new [] {1,4,4,4,5},12)]
        [InlineData(new [] {3,3,4,5,6},0)]
        [InlineData(new [] {3,3,3,3,1},9)]
        public void Should_Test_ThreeOfAKind(int[] turn, int expected)
        {
            // arrange
            var target = new ThreeOfAKind();
            // act
            var result = target.Score(turn);
            // assert
            Assert.Equal(expected, result);
        }
    }
}