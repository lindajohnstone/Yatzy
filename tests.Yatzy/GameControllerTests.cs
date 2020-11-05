using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy;

namespace tests.Yatzy
{
    public class GameControllerTests
    {
        [Fact]
        public void Should_Roll_No_More_Than_Three_Times()
        {
            // arrange
            var reader = new Mock<IInputReader>();
            reader.SetupSequence(o => o.GetPlayerRollChoice()).Returns(Choice.Hold).Returns(Choice.Hold);
            reader.SetupSequence(o => o.GetDiceToHold()).Returns(new int[] { 1, 2 }).Returns(new int[] { 3, 5 });
            var writer = new Mock<IOutputWriter>();
            var controller = new GameController(reader.Object, writer.Object);

            // act
            controller.RunGame();

            // assert
            reader.Verify(o => o.GetPlayerRollChoice(), Times.Exactly(2));
            reader.Verify(o => o.GetDiceToHold(), Times.Exactly(2));
        }

        [Fact]
        public void Should_Score_Player_Turn_In_Scoreboard()
        {
            // arrange
            var reader = new Mock<IInputReader>();
            var categories = new List<Category>();
            reader.SetupSequence(o => o.GetPlayerRollChoice()).Returns(Choice.Hold).Returns(Choice.Hold);
            reader.SetupSequence(o => o.GetDiceToHold()).Returns(new int[] { 1, 2 }).Returns(new int[] { 3, 5 });
            reader.Setup(o => o.GetCategoryChoice(categories)).Returns(Category.Chance);
            var writer = new Mock<IOutputWriter>();
            var controller = new GameController(reader.Object, writer.Object);

            // act
            controller.RunGame();

            // assert
            reader.Verify(o => o.GetCategoryChoice(categories), Times.AtLeastOnce);
            reader.Verify(o => o.GetCategoryChoice(categories), Times.AtMost(15));
        }
    }
}