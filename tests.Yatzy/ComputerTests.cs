using Moq;
using Xunit;
using Yatzy;

namespace tests.Yatzy
{
    public class ComputerTests
    {
        [Fact]
        public void Should_Test_Computer_Ends_Turn_On_Yatzee_And_Ends()
        {
            // arrange
            var turn = new DiceControllerComputerStub(0);
            var writer = new Mock<IOutputWriter>();
            var formatter = new Mock<IOutputFormatter>();
            var computerPlayer = new Computer(1, new Scorecard(), writer.Object, formatter.Object);
            // act
            var result = computerPlayer.PlayOneTurn(turn);
            computerPlayer.ScoreOneTurn(result);
            // assert
            Assert.Equal(new int[] { 5, 5, 5, 5, 5}, result.Dice);
            Assert.Equal(50, computerPlayer.Scorecard.Scores[Category.Yatzee]);
        }
        [Fact]
        public void Should_Test_Computer_Will_Hold_And_Reroll_Low_Value_Die()
        {
            var turn = new DiceControllerComputerStub(1);
            var writer = new Mock<IOutputWriter>();
            var formatter = new Mock<IOutputFormatter>();
            var computerPlayer = new Computer(1, new Scorecard(), writer.Object, formatter.Object);
            // act
            var result = computerPlayer.PlayOneTurn(turn);
            computerPlayer.ScoreOneTurn(result);
            // assert
            Assert.Equal(new int[] { -1, -1, -1, -1, 4}, result.Dice);
            Assert.Equal(4, computerPlayer.Scorecard.Scores[Category.Fours]);
        }
    }
}