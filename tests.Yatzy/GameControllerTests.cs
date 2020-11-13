using System;
using System.Collections.Generic;
using System.Linq;
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
            var reader = new StubHoldInput();
            var writer = new Mock<IOutputWriter>();
            var controller = new GameController(reader, writer.Object, new OutputFormatter());

            // act
            controller.RunGame();

            // assert
            Assert.Equal(30, reader.getPlayerRollChoiceCount);
            Assert.Equal(30, reader.getDiceToHoldCount);
        }

        [Fact]
        public void Should_Score_Player_Turn_In_Scoreboard()
        {
            // arrange
            var reader = new StubEndInput();
            var writer = new Mock<IOutputWriter>();
            var controller = new GameController(reader, writer.Object, new OutputFormatter());

            // act
            controller.RunGame();

            // assert
            Assert.Equal(15, reader.getCategoryChoiceCount);
        }
    }
}